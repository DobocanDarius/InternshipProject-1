using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Posts.Request;

public class UpdatePostRequest
{
    public string? Title { get; set; }

    public string? Body { get; set; }
}
