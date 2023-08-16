using RequestResponseModels.Posts.Response;
using RequestResponseModels.Users.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Comments.Response;

public class GetCommentResponse
{
    public GetCommentResponse(int id, string text, int userId, int postId, int? upVotes, DateTime? createdAt)
    {
        Id = id;
        Text = text;
        UserId = userId;
        PostId = postId;
        UpVotes = upVotes;
        CreatedAt = createdAt;
    }
    public int Id { get; set; }

    public string? Text { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }

    public int? UpVotes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual GetPostResponse Post { get; set; } = null!;

    public virtual UserResponse User { get; set; } = null!;
}
