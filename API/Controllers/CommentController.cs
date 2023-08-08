using API.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Comments.Request;
using RequestResponseModels.Comments.Response;
using WebApi.Manager;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentManager _commentManager;

    public CommentController(ICommentManager commentManager)
    {
        _commentManager = commentManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCommentResponse>>> GetComments()
    {
        try
        {
            var comments = await _commentManager.GetComments();
            return Ok(comments);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
    [HttpGet("{postId}")]
    public async Task<ActionResult<IEnumerable<GetCommentResponse>>> GetCommentsByPost(int postId)
    {
        try
        {
            var comments = await _commentManager.GetCommentsByPost(postId);
            return Ok(comments);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> InsertComment(InsertCommentRequest newComment)
    {
        try
        {
            await _commentManager.InsertComment(newComment);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateComment(UpdateCommentRequest newComment, int id)
    {
        try
        {
            await _commentManager.UpdateComment(newComment, id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteComment(int id)
    {
        try
        {
            await _commentManager.DeleteComment(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}
