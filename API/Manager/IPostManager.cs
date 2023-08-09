using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;

namespace WebApi.Manager
{
    public interface IPostManager
    {
        Task<IEnumerable<GetPostResponse>> GetPosts();
        Task InsertPost(InsertPostRequest newPost);
        Task UpdatePost(UpdatePostRequest newPost, int id);
        Task DeletePost(int id);
        Task<IEnumerable<GetPostResponse>> GetPostsByTopic(int id);
        Task UpVotePost(int id);
    }
}