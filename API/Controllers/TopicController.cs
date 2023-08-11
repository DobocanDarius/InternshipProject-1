using API.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Topics.Request;
using RequestResponseModels.Topics.Response;
using RequestResponseModels.Users.Response;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicManager _topicManager;

        public TopicController(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTopicResponse>>> GetTopics()
        {
            try
            {
                var users = await _topicManager.GetTopics();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> InsertTopic(GetTopicRequest newTopic)
        {
            try
            {
                await _topicManager.InsertTopic(newTopic);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTopic(int id)
        {
            try
            {
                await _topicManager.DeleteTopic(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
