using RequestResponseModels.Comments.Response;

namespace UI.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentResponse>> FindByPost(int postId);
    }
}