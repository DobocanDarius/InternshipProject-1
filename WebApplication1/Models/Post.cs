using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public int? UpVotes { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public int? UserId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? User { get; set; }

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
