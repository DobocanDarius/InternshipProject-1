using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Request;
using Models.Response;

namespace WebApplication1.Controllers.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly LocalDbContext localDbContext;

        public TopicController(LocalDbContext localDbContext)
        {
            this.localDbContext = localDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<TopicResponse>>> GetTopics()
        {
            try
            {
                var topics = await localDbContext.Topics.Include(p => p.Posts).ToListAsync();

                List<TopicResponse> topicResponse = new List<TopicResponse>();
                foreach (var topic in topics)
                {
                    var postResponses = topic.Posts.Select(post =>
                        new PostResponse(post.Id,post.Title,post.Body,post.UserId, (List<CommentResponse>)post.Comments, (List<TopicResponse>)post.Topics)).ToList();

                    topicResponse.Add(new TopicResponse(
                        topic.Id,
                        topic.Topic1,
                        postResponses));
                }

                return topicResponse;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicResponse>> GetTopics(int id)
        {
            try
            {
                var topic = await localDbContext.Topics.FindAsync(id);
                if (topic == null)
                {
                    return BadRequest("User does not exist");
                }
                return new TopicResponse(topic.Id, topic.Topic1, (List<PostResponse>)topic.Posts);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<TopicResponse>> InsertTopics(TopicRequest newTopic)
        {
            try
            {

                var topic = new Topic
                {
                    Topic1 = newTopic.Topic1
                };

                localDbContext.Topics.Add(topic);
                await localDbContext.SaveChangesAsync();

                var topicResponse = new TopicResponse(topic.Id, topic.Topic1, (List<PostResponse>)topic.Posts);

                return CreatedAtAction(nameof(GetTopics), new { id = topic.Id }, topicResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TopicResponse>> UpdateTopics(TopicRequest updateTopic, int id)
        {
            try
            {
                var dbTopic = await localDbContext.Topics.FindAsync(id);
                if (dbTopic == null)
                {
                    return BadRequest("Topic does not exist");
                }

                dbTopic.Topic1 = updateTopic.Topic1;
                await localDbContext.SaveChangesAsync();

                return Ok(dbTopic);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTopics(int id)
        {
            try
            {
                var dbTopic = await localDbContext.Topics.FindAsync(id);
                if (dbTopic == null)
                {
                    return BadRequest("Topic does not exist");
                }

                localDbContext.Topics.Remove(dbTopic);
                await localDbContext.SaveChangesAsync();

                return StatusCode(200, $"User deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
