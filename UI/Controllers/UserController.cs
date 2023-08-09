using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RequestResponseModels.Users.Request;
using RequestResponseModels.Users.Response;
using System.Net.Http;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                var response = await client.PostAsJsonAsync("https://localhost:7287/api/User/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(content);

                    if (loginResponse.Token != null)
                    {
                        HttpContext.Response.Cookies.Append("AuthToken", loginResponse.Token);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View(loginRequest);
        }
    }
}
