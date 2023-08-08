using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Posts.Request;
using UI.Services;

namespace UI.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _service;
        public PostController(ILogger<PostController> logger, IPostService service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));

        }
        public async Task<IActionResult> PostByIndex(int topicId)
        {
            var products = await _service.FindByTopic(topicId);
            return View(products);
        }

        public IActionResult CreatePost()
        {
            return View();
        }
        public IActionResult Confirm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(InsertPostRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.CreatePost(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Confirm");
                }
                else
                {
                }
            }

            return View(request);
        }
    }
}
