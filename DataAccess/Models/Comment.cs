using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }

        public int? UpVotes { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Post Post { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
