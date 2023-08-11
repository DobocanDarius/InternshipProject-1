using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class PostModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int UpVotes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int UserId { get; set; }
}
