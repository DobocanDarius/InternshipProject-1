using DataAccess.Repository;
using RequestResponseModels.Users.Response;
using RequestResponseModels.Users.Request;
namespace API.Manager;

public class UserManager : IUserManager
{
    private readonly IUser _userRepository;

    public UserManager(IUser userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<GetUserResponse>> GetUsers()
    {
        var users = await _userRepository.GetUsers();

        var response = users.Select(p => new GetUserResponse(p.Id, p.UserName));

        return response;
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
