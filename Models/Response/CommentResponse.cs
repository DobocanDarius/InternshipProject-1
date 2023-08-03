using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response;

public class CommentResponse
{
    public CommentResponse(int id, string? text)
    {
        Id = id;
        Text = text;
    }

    public CommentResponse(int id, string text, int userId, int postId)
    {
        Id = id;
        Text = text;
        UserId = userId;
        PostId = postId;
    }
    public int Id { get; set; }

    public string? Text { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }

    public int? UpVotes { get; set; } = 0;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

}
