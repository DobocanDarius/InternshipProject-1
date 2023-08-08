using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Posts.Request;
using UI.Services;

namespace UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly IPostService _service;
        public CommentController(ILogger<CommentController> logger, IPostService service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));

        }
        public async Task<IActionResult> CommentByPost(int postId)
        {
            var products = await _service.FindByTopic(postId);
            return View(products);
        }
    }
}
