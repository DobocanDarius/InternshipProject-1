using DataAccess.DbAccess;
using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ISqlDataAccess _db;

        public PostRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<GetPostResponse>> GetPosts() =>
         _db.LoadData<GetPostResponse, dynamic>("dbo.sp_PostGetAll", new { });
        
          

        public Task InsertPost(InsertPostRequest post) =>
            _db.SaveData("dbo.sp_PostInsert", new { post.Title, post.Body, post.UserId, UpVotes = 0, CreatedAt = DateTime.Now, post.TopicId });
        public async Task<IEnumerable<GetPostResponse?>> GetPostByTopic(int id)
        {
            var results = await _db.LoadData<GetPostResponse, dynamic>("dbo.sp_PostGetByTopic", new { Id = id });
            return results.ToList();
        }

        public async Task<IEnumerable<GetPostResponse?>> GetPostByUser(int id)
        {
            var results = await _db.LoadData<GetPostResponse, dynamic>("dbo.sp_PostGetByUser", new { Id = id });
            return results.ToList();
        }
        public Task UpdatePost(UpdatePostRequest post, int id) =>
            _db.SaveData("dbo.sp_PostUpdate", new { Id = id, post.Title, post.Body });

        public Task UpVotePost(int id) =>
           _db.SaveData("dbo.sp_PostUpVote", new { Id = id });

        public Task DeletePost(int id) =>
            _db.SaveData("dbo.sp_PostDelete", new { Id = id });
    }
}
