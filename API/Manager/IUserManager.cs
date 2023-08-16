using RequestResponseModels.Users.Request;
using RequestResponseModels.Users.Response;

namespace API.Manager
{
    public interface IUserManager
    {
        Task DeleteUser(int id);
        Task InsertUser(InsertUserRequest newUser);
        Task<LoginResponse>? LogIn(LoginRequest user);
        Task UpdateUser(InsertUserRequest user, int id);
        Task<UserResponse> Users();
    }
}