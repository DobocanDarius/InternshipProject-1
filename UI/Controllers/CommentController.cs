using Microsoft.AspNetCore.Mvc;
using UI.Services;

namespace UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _service;
        public CommentController(ILogger<CommentController> logger, ICommentService service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));

        }
        public async Task<IActionResult> CommentByPost(int postId)
        {
            var products = await _service.FindByPost(postId);
            return View(products);
        }
    }
}
