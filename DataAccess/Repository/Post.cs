using DataAccess.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Post : IPost
    {
        private readonly ISqlDataAccess _db;

        public Post(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<Models.Post>> GetPosts() =>
         _db.LoadData<Models.Post, dynamic>("dbo.sp_PostGetAll", new { });
        
          

        public Task InsertPost(Models.Post post) =>
            _db.SaveData("dbo.sp_PostInsert", new { post.Title, post.Body, post.UserId, UpVotes = 0, CreatedAt = DateTime.Now, post.TopicId });
        public async Task<IEnumerable<Models.Post?>> GetPostByTopic(int id)
        {
            var results = await _db.LoadData<Models.Post, dynamic>("dbo.sp_PostGetByTopic", new { Id = id });
            return results.ToList();
        }
        public Task UpdatePost(Models.Post post, int id) =>
            _db.SaveData("dbo.sp_PostUpdate", new { Id = id, post.Title, post.Body });

        public Task UpVotePost(Models.Post post, int id) =>
           _db.SaveData("dbo.sp_PostUpVote", new { Id = id });

        public Task DeletePost(int id) =>
            _db.SaveData("dbo.sp_PostDelete", new { Id = id });
    }
}
