using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Comments.Request;

public class InsertCommentRequest
{
    public string? Text { get; set; }

    public int UserId { get; set; }
    public int PostId { get; set; }
}
