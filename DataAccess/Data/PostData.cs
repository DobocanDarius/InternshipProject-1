using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class PostData : IPostData
{
    private readonly ISqlDataAccess _db;

    public PostData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<PostModel>> GetPosts() =>
        _db.LoadData<PostModel, dynamic>("dbo.sp_PostGetAll", new { });
}
