using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;

namespace UI.Services
{
    public interface IPostService
    {
        Task<HttpResponseMessage> CreatePost(InsertPostRequest post);
        Task<IEnumerable<GetPostResponse>> Find();
        Task<IEnumerable<GetPostResponse>> FindByTopic(int topicId);
    }
}