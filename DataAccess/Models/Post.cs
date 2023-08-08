using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public int? UpVotes { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public int? UserId { get; set; }
    public int? TopicId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? User { get; set; }

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
