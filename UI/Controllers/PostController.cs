using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

        public async Task<IActionResult> PostByUser()
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
                        var products = await _service.FindByUser(userId);

                        return View("Get", products);
                    }
                }
                catch (SecurityTokenValidationException)
                {

                }
            }
            return View();
        }

        public IActionResult CreatePost()
        {

            return View();
        }
        public IActionResult Confirm()
        {
            return View();
        }
        public async Task <IActionResult> DeletePost(int postId)
        {
            await _service.DeletePost(postId);
            return RedirectToAction("Index", "Home");
            
        }

        public async Task<IActionResult> UpVotePost(int postId)
        {
            await _service.UpVotePost(postId);
            return RedirectToAction("Index", "Home");

        }
        public IActionResult UpdatePost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePost(int id, UpdatePostResponse updatedPost)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.UpdatePost(id, new UpdatePostRequest
                    {
                        Title = updatedPost.Title,
                        Body = updatedPost.Body
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home"); 
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to update post.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            return View(updatedPost);
        }


        [HttpPost]
    
        public async Task<IActionResult> CreatePost(InsertPostRequest request)
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

                            var response = await _service.CreatePost(request);

                            if (response.IsSuccessStatusCode)
                            {
                                return RedirectToAction("Confirm");
                            }
                        }
                    }
                    catch (SecurityTokenValidationException)
                    {
                       
                    }
                }
            }

            return View(request);
        }
    }
}
