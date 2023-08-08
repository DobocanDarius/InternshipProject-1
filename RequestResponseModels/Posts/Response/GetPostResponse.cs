using RequestResponseModels.Comments.Response;
using RequestResponseModels.Topics.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Posts.Response;

public class GetPostResponse
{
    public GetPostResponse(int id, string title, string body, int? userId, int? upVotes, DateTime createdAt, int? topicId)
    {
        Id = id;
        Title = title;
        Body = body;
        UserId = userId;
        UpVotes = upVotes;
        CreatedAt = createdAt;
        TopicId = topicId;
    }
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public int? UpVotes { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? UserId { get; set; }
    public int? TopicId { get; set; }

    public virtual ICollection<CommentResponse> Comments { get; set; }

    public virtual ICollection<GetTopicRequest> Topics { get; set; }
}
