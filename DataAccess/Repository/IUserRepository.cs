using RequestResponseModels.Users.Request;
using RequestResponseModels.Users.Response;

namespace DataAccess.Repository
{
    public interface IUserRepository
    {
        Task DeleteUser(int id);
        Task<UserResponse?> GetUser(int id);
        Task<IEnumerable<Models.User>> Users();
        Task InsertUser(InsertUserRequest user);
        Task UpdateUser(InsertUserRequest user, int id);
        Task<IEnumerable<Models.User>> SearchUser(string userName, string password);
    }
}