using RequestResponseModels.Posts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Topics.Response;

public class GetTopicResponse
{
    public GetTopicResponse(int? id, string? text)
    {
        Id = id;
        Text = text;
    }
    public int? Id { get; set; }
    public string? Text { get; set; }

}
