using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class TopicResponse
    {
        public TopicResponse(int id, string? topic1)
        {
            Id = id;
            Topic1 = topic1;
        }

        public TopicResponse(int id, string topic, ICollection<PostResponse> posts)
        {
            Id = id;
            Topic1 = topic;
            Posts = posts;
        }
        public int Id { get; set; }

        public string? Topic1 { get; set; }

        public virtual ICollection<PostResponse> Posts { get; set; }
    }
}
