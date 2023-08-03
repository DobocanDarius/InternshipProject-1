using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Topic
{
    public int Id { get; set; }

    public string? Topic1 { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
