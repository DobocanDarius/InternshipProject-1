using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Comment : IComment
    {
        private readonly ISqlDataAccess _db;

        public Comment(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<Models.Comment>> GetComments() =>
            _db.LoadData<Models.Comment, dynamic>("dbo.sp_CommentGetAll", new { });

        public Task InsertComment(Models.Comment comment) =>
            _db.SaveData("dbo.sp_CommentInsert", new { comment.Text, comment.UserId, comment.PostId, UpVotes = 0, CreatedAt = DateTime.Now });

        public Task UpdateComment(Models.Comment comment, int id) =>
            _db.SaveData("dbo.sp_CommentUpdate", new { Id = id, comment.Text });

        public async Task<IEnumerable<Models.Comment?>> GetCommentByPost(int id)
        {
            var results = await _db.LoadData<Models.Comment, dynamic>("dbo.sp_CommentGetByPost", new { Id = id });
            return results.ToList();
        }

        public Task DeleteComment(int id) =>
            _db.SaveData("dbo.sp_CommentDelete", new { Id = id });
    }
}
