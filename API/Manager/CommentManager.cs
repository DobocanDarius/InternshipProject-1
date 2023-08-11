using DataAccess.Repository;
using RequestResponseModels.Comments.Request;
using RequestResponseModels.Comments.Response;

namespace API.Manager;

public class CommentManager : ICommentManager
{
    private readonly IComment _commentRepository;

    public CommentManager(IComment commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<GetCommentResponse>> GetComments()
    {
        var comments = await _commentRepository.GetComments();

        var response = comments.Select(p => new GetCommentResponse(p.Id, p.Text, p.UserId, p.PostId, p.UpVotes, p.CreatedAt));

        return response;
    }
    public async Task<IEnumerable<GetCommentResponse>> GetCommentsByPost(int id)
    {
        var comments = await _commentRepository.GetCommentByPost(id);

        var response = comments.Select(p => new GetCommentResponse(p.Id, p.Text, p.UserId, p.PostId, p.UpVotes, p.CreatedAt));

        return response;
    }

    public async Task InsertComment(InsertCommentRequest newComment)
    {
        var comment = new DataAccess.Models.Comment
        {
            Text = newComment.Text,
            UserId = newComment.UserId,
            PostId = newComment.PostId
        };
        await _commentRepository.InsertComment(comment);
    }

    public async Task UpdateComment(UpdateCommentRequest comment, int id)
    {
        var commentToUpdate = new DataAccess.Models.Comment
        {
            Text = comment.Text
        };

        await _commentRepository.UpdateComment(commentToUpdate, id);
    }

    public async Task DeleteComment(int id)
    {
        await _commentRepository.DeleteComment(id);
    }
}
