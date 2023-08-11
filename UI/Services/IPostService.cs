using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;

namespace UI.Services
{
    public interface IPostService
    {
        Task<HttpResponseMessage> CreatePost(InsertPostRequest post);
        Task<HttpResponseMessage> DeletePost(int postId);
        Task<IEnumerable<GetPostResponse>> Find();
        Task<IEnumerable<GetPostResponse>> FindByTopic(int topicId);
        Task<IEnumerable<GetPostResponse>> FindByUser(int userId);
        Task<HttpResponseMessage> UpdatePost(int postId, UpdatePostRequest newPost);
        Task<HttpResponseMessage> UpVotePost(int postId);
    }
}