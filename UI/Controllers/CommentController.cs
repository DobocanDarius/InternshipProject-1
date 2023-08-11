using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RequestResponseModels.Comments.Request;
using RequestResponseModels.Comments.Response;
using RequestResponseModels.Posts.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
            var comments = await _service.FindByPost(postId);
            ViewBag.PostId = postId; 
            return View(comments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(int postId, InsertCommentRequest request)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Cookies.TryGetValue("AuthToken", out string authToken))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var validationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jj2e2VFqjCQoRoElxKkrKMGS3TYOTWxk")),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    try
                    {
                        var claimsPrincipal = tokenHandler.ValidateToken(authToken, validationParameters, out _);

                        if (int.TryParse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
                        {
                            request.UserId = userId;
                            request.PostId = postId;
                            var response = await _service.AddComment(request);
                            var products = await _service.FindByPost(postId);
                            return View("CommentByPost", products);
                        }
                    }
                    catch (SecurityTokenValidationException)
                    {

                    }
                }
                else
                {
                    request.UserId = 4003;
                    request.PostId = postId;
                    var response = await _service.AddComment(request);
                    var products = await _service.FindByPost(postId);
                    return View("CommentByPost", products);
                }
            }

            var comments = await _service.FindByPost(postId);
            return View("CommentByPost", comments);
        }
    }
}
