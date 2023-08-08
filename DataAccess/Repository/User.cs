using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository;

public class User : IUser
{
    private readonly ISqlDataAccess _db;

    public User(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Models.User>> GetUsers() =>
        _db.LoadData<Models.User, dynamic>("dbo.sp_UserGetAll", new { });

    public async Task<Models.User?> GetUser(int id)
    {
        var results = await _db.LoadData<Models.User, dynamic>("dbo.sp_UserGet", new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(Models.User user) =>
        _db.SaveData("dbo.sp_UserInsert", new { user.UserName, user.Password });

    public Task UpdateUser(Models.User user, int id) =>
        _db.SaveData("dbo.sp_UserUpdate", new { Id = id, user.UserName, user.Password });

    public Task DeleteUser(int id) =>
        _db.SaveData("dbo.sp_UserDelete", new { Id = id });
}