using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;

namespace WebApi.Manager
{
    public class PostManager
    {
        private readonly IPost _data;

        public async Task<ActionResult<List<GetCommentResponse>>> Get()
        {
            var posts = await _data.GetPosts();

            List<GetCommentResponse> postResponse = new List<GetCommentResponse>();
            foreach (var post in posts)
            {
                postResponse.Add(new GetResponse(
                    post.Id,
                    post.Title,
                    post.Body,
                    post.UserId,
                    post.UpVotes));
            }

            return postResponse;
        }

    }
    
}
