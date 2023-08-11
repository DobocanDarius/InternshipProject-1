using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RequestResponseModels.Users.Request;
using RequestResponseModels.Users.Response;

using UI.Services;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUserService _service;

        public UserController(IHttpClientFactory httpClientFactory, IUserService service)
        {
            _httpClientFactory = httpClientFactory;
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
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

        [HttpPost]

        public async Task<IActionResult> Register(InsertUserRequest request)
        {
            if (ModelState.IsValid)
            {
                    try
                    {
                        var response = await _service.CreateUser(request);
                        return RedirectToAction("Login", "User");
                    }
                    catch (SecurityTokenValidationException)
                    {

                    }
            }
            return RedirectToAction("Login", "User");
        }
        

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("AuthToken");

            return RedirectToAction("Index", "Home");
        }
    }
}
