namespace DataAccess.Repository
{
    public interface IUser
    {
        Task DeleteUser(int id);
        Task<Models.User?> GetUser(int id);
        Task<IEnumerable<Models.User>> GetUsers();
        Task InsertUser(Models.User user);
        Task UpdateUser(Models.User user, int id);
    }
}