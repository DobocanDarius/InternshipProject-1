using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Repository;
using RequestResponseModels.Users.Request;
using RequestResponseModels.Users.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository;

public class UserRepository : IUserRepository
{
    private readonly ISqlDataAccess _db;

    public UserRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Models.User>> Users() =>
        _db.LoadData<Models.User, dynamic>("dbo.sp_UserGetAll", new { });

    public async Task<UserResponse?> GetUser(int id)
    {
        var results = await _db.LoadData<UserResponse, dynamic>("dbo.sp_UserGet", new { Id = id });
        return results.FirstOrDefault();
    }

    public Task<IEnumerable<Models.User>> SearchUser(string userName, string password) => 
        _db.LoadData<Models.User, dynamic>("dbo.sp_UserAuth", new { UserName = userName, Password = password });

    public Task InsertUser(InsertUserRequest user) =>
        _db.SaveData("dbo.sp_UserInsert", new { user.UserName, user.Password });

    public Task UpdateUser(InsertUserRequest user, int id) =>
        _db.SaveData("dbo.sp_UserUpdate", new { Id = id, user.UserName, user.Password });

    public Task DeleteUser(int id) =>
        _db.SaveData("dbo.sp_UserDelete", new { Id = id });

    
}