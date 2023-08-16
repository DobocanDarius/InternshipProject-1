using DataAccess.Repository;
using RequestResponseModels.Users.Response;
using RequestResponseModels.Users.Request;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using API.Helpers;
using DataAccess.Models;

namespace API.Manager;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;
    private TokenManager _tokenManager;
    private PasswordHash _passwordHash;

    public UserManager(IUserRepository userRepository, TokenManager tokenManager, PasswordHash passwordHash)
    {
        _userRepository = userRepository;
        _tokenManager = tokenManager;
        _passwordHash = passwordHash;
    }

    public async Task<UserResponse> Users()
    {
        var users = await _userRepository.Users();

        var userResult = users.Select(u => new UserRequest(u.Id, u.UserName));

        return new UserResponse { Users = userResult };
    }
    public async Task<LoginResponse>? LogIn(LoginRequest unauthenticatedUser)
    {
        var user = await _userRepository.SearchUser(unauthenticatedUser.UserName, _passwordHash.HashPassword(unauthenticatedUser.Password));

        var userResult = user.Select(u => new LoginRequest(u.Id, u.UserName, _passwordHash.HashPassword(u.Password)));

        if (userResult.Count() == 1)
        {
            return new LoginResponse { Users = userResult, Token = _tokenManager.CreateToken(userResult.FirstOrDefault()) };
        }

        return null;
    }

    public async Task InsertUser(InsertUserRequest newUser)
    {
        var user = new InsertUserRequest
        {
            UserName = newUser.UserName,
            Password = _passwordHash.HashPassword(newUser.Password)
        };
        await _userRepository.InsertUser(user);
    }

    public async Task UpdateUser(InsertUserRequest user, int id)
    {
        var userToUpdate = new InsertUserRequest
        {
            UserName = user.UserName,
            Password = user.Password
        };

        await _userRepository.UpdateUser(userToUpdate, id);
    }

    public async Task DeleteUser(int id)
    {
        await _userRepository.DeleteUser(id);
    }
}
