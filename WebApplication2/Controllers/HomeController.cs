using Microsoft.AspNetCore.Mvc;
using Models.Response;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static readonly string url = "https://localhost:7291";

        private async Task<List<PostResponse>> GetAllPosts()
        {
            List<PostResponse> postsInfo = new List<PostResponse>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"{url}/api/Post");
                if (response.IsSuccessStatusCode)
                {
                    var posts = await response.Content.ReadFromJsonAsync<IEnumerable<PostResponse>>(
                     new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (posts != null)
                        return posts.ToList();
                }
            }
            return postsInfo;
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var response = GetAllPosts().Result;
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}