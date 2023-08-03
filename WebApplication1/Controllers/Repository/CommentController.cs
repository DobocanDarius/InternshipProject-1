using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Request;
using Models.Response;

namespace WebApplication1.Controllers.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly LocalDbContext localDbContext;

        public CommentController(LocalDbContext localDbContext)
        {
            this.localDbContext = localDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentResponse>>> GetComments()
        {
            try
            {
                var comments = await localDbContext.Comments.ToListAsync();
                List<CommentResponse> commentResponse = new List<CommentResponse>();
                foreach (var comment in comments)
                {
                    commentResponse.Add(new CommentResponse(comment.Id, comment.Text, comment.UserId, comment.PostId));
                }
                return commentResponse;
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentResponse>> GetComments(int id)
        {
            try
            {
                var comment = await localDbContext.Comments.FindAsync(id);
                if (comment == null)
                {
                    return BadRequest("Comment does not exist");
                }
                return new CommentResponse(comment.Id, comment.Text, comment.UserId, comment.PostId);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }
        [HttpPost]
        public async Task<ActionResult<CommentResponse>> InsertComment(CommentRequest newComment)
        {
            try
            {
                var comment = new Comment
                {
                    Text = newComment.Text,
                    UserId = newComment.UserId,
                    PostId = newComment.PostId
                };

                localDbContext.Comments.Add(comment);
                await localDbContext.SaveChangesAsync();

                var commentResponse = new CommentResponse(comment.Id, comment.Text, comment.UserId, comment.PostId);

                return CreatedAtAction(nameof(GetComments), new { id = comment.Id }, commentResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CommentResponse>> UpdateComments(CommentRequest updateComment, int id)
        {
            try
            {
                var dbComment = await localDbContext.Comments.FindAsync(id);
                if (dbComment == null)
                {
                    return BadRequest("Comment does not exist");
                }

                dbComment.Text = updateComment.Text;

                await localDbContext.SaveChangesAsync();

                return Ok(dbComment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComments(int id)
        {
            try
            {
                var dbComment = await localDbContext.Comments.FindAsync(id);
                if (dbComment == null)
                {
                    return BadRequest("Comment does not exist");
                }

                localDbContext.Comments.Remove(dbComment);
                await localDbContext.SaveChangesAsync();

                return StatusCode(200, $"Comment deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
