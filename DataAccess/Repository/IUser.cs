using RequestResponseModels.Users.Request;
using RequestResponseModels.Users.Response;

namespace DataAccess.Repository
{
    public interface IUser
    {
        Task DeleteUser(int id);
        Task<Models.User?> GetUser(int id);
        Task<IEnumerable<Models.User>> GetUsers();
        Task InsertUser(Models.User user);
        Task<LoginResponse> SearchUser(string userName, string password);
        Task UpdateUser(Models.User user, int id);
    }
}