using RequestResponseModels.Posts.Response;

namespace UI.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<GetPostResponse>> FindByPost(int postId);
    }
}