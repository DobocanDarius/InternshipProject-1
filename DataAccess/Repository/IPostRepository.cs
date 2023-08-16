using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;

namespace DataAccess.Repository
{
    public interface IPostRepository
    {
        Task DeletePost(int id);
        Task<IEnumerable<GetPostResponse?>> GetPostByTopic(int id);
        Task<IEnumerable<GetPostResponse?>> GetPostByUser(int id);
        Task<IEnumerable<GetPostResponse>> GetPosts();
        Task InsertPost(InsertPostRequest post);
        Task UpdatePost(UpdatePostRequest post, int id);
        Task UpVotePost(int id);
    }
}