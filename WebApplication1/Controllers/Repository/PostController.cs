using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using Models.Request;
using Models.Response;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly LocalDbContext localDbContext;

        public PostController(LocalDbContext localDbContext)
        {
            this.localDbContext = localDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostResponse>>> GetPosts()
        {
            try
            {
                var posts = await localDbContext.Posts.Include(p => p.Comments).ToListAsync();

                List<PostResponse> postResponse = new List<PostResponse>();
                foreach (var post in posts)
                {
                    var commentResponses = post.Comments.Select(comment =>
                        new CommentResponse(comment.Id, comment.Text)).ToList();
                    var topicResponses = post.Topics.Select(topic =>
                        new TopicResponse(topic.Id, topic.Topic1)).ToList();

                    postResponse.Add(new PostResponse(
                        post.Id,
                        post.Title,
                        post.Body,
                        post.UserId,
                        commentResponses,
                        topicResponses));
                }

                return postResponse;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostResponse>> GetPosts(int id)
        {
            try
            {
                var post = await localDbContext.Posts.FindAsync(id);
                if (post == null)
                {
                    return BadRequest("User does not exist");
                }
                return new PostResponse(post.Id, post.Title, post.Body, post.UserId, (List<CommentResponse>)post.Comments, (List<TopicResponse>)post.Topics);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<PostResponse>> InsertPosts(PostRequest newPost)
        {
            try
            {

                var post = new Post
                {
                    Title = newPost.Title,
                    Body = newPost.Body,
                    UserId = newPost.UserId,
                };

                localDbContext.Posts.Add(post);
                await localDbContext.SaveChangesAsync();

                var postResponse = new PostResponse(post.Id, post.Title, post.Body, post.UserId, (List<CommentResponse>)post.Comments, (List<TopicResponse>)post.Topics);

                return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, postResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostResponse>> UpdatePosts(PostRequest updatePost, int id)
        {
            try
            {
                var dbPost = await localDbContext.Posts.FindAsync(id);
                if (dbPost == null)
                {
                    return BadRequest("Post does not exist");
                }

                dbPost.Title = updatePost.Title;
                dbPost.Body = updatePost.Body;
                dbPost.UpVotes += 1;
                await localDbContext.SaveChangesAsync();

                return Ok(dbPost);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePosts(int id)
        {
            try
            {
                var dbPost = await localDbContext.Posts.FindAsync(id);
                if (dbPost == null)
                {
                    return BadRequest("Post does not exist");
                }

                localDbContext.Posts.Remove(dbPost);
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
