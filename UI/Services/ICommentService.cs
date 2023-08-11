using RequestResponseModels.Comments.Request;
using RequestResponseModels.Comments.Response;

namespace UI.Services
{
    public interface ICommentService
    {
        Task<HttpResponseMessage> AddComment(InsertCommentRequest comment);
        Task<IEnumerable<CommentResponse>> FindByPost(int postId);
    }
}