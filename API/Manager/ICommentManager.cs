using RequestResponseModels.Comments.Request;
using RequestResponseModels.Comments.Response;

namespace API.Manager
{
    public interface ICommentManager
    {
        Task DeleteComment(int id);
        Task<IEnumerable<GetCommentResponse>> GetComments();
        Task<IEnumerable<GetCommentResponse>> GetCommentsByPost(int id);
        Task InsertComment(InsertCommentRequest newComment);
        Task UpdateComment(UpdateCommentRequest comment, int id);
    }
}