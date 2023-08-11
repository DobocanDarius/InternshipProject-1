using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Comments.Response;

public class CommentResponse
{
   public int Id { get; set; }
   public string? Text { get; set; }

   public int UpVotes { get; set; }
}
