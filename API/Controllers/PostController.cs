using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;
using System.Xml.Linq;
using WebApi.Manager;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostManager _postManager;

    public PostController(IPostManager postManager)
    {
        _postManager = postManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetPostResponse>>> GetPosts()
    {
        try
        {
            var posts = await _postManager.GetPosts();
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpGet ("{topicId}")]
    public async Task<ActionResult<IEnumerable<GetPostResponse>>> GetPostsByTopic(int topicId)
    {
        try
        {
            var posts = await _postManager.GetPostsByTopic(topicId);
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> InsertPost(InsertPostRequest newPost)
    {
        try
        {
            await _postManager.InsertPost(newPost);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpPut ("{id}")]
    public async Task<ActionResult> UpdatePost(UpdatePostRequest newPost, int id)
    {
        try
        {
            await _postManager.UpdatePost(newPost, id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        try
        {
            await _postManager.DeletePost(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}

