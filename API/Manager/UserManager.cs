using DataAccess.Repository;
using RequestResponseModels.Users.Response;
using RequestResponseModels.Users.Request;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using API.Helpers;

namespace API.Manager;

public class UserManager : IUserManager
{
    private readonly IUser _userRepository;
    private TokenManager _tokenManager;
    public UserManager(IUser userRepository, TokenManager tokenManager)
    {
        _userRepository = userRepository;
        _tokenManager = tokenManager;
    }

    public async Task<IEnumerable<GetUserResponse>> GetUsers()
    {
        var users = await _userRepository.GetUsers();

        var response = users.Select(p => new GetUserResponse(p.Id, p.UserName));

        return response;
    }
    public async Task<LoginResponse>? LogIn(LoginRequest unauthenticatedUser)
    {
        LoginResponse user = await _userRepository.SearchUser(unauthenticatedUser.UserName, unauthenticatedUser.Password);

        if (user != null)
        {
            return new LoginResponse(user.Id, user.UserName, user.Password, _tokenManager.CreateToken(user));
        }

        return null;
    }

    public async Task InsertUser(InsertUserRequest newUser)
    {
        var user = new DataAccess.Models.User
        {
            UserName = newUser.UserName,
            Password = newUser.Password
        };
        await _userRepository.InsertUser(user);
    }

    public async Task UpdateUser(InsertUserRequest user, int id)
    {
        var userToUpdate = new DataAccess.Models.User
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
