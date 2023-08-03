using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models.Response;

public class PostResponse
{
    
    public PostResponse(int id, string title, string body, int? userId, ICollection<CommentResponse> comments, ICollection<TopicResponse> topics)
    {
        Id = id; 
        Title = title;
        Body = body;
        UserId = userId;
        Comments = comments;
        Topics = topics;
    }
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public int? UpVotes { get; set; } = 0;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public int? UserId { get; set; }

    public virtual ICollection<CommentResponse> Comments { get; set; }

    public virtual ICollection<TopicResponse> Topics { get; set; }
}
