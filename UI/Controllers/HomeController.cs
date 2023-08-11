using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;
using UI.Services;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _service;
        public HomeController(ILogger<HomeController> logger, IPostService service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));

        }

        public async Task<IActionResult> IndexAsync()
        {
            ViewBag.TokenExists = HttpContext.Request.Cookies["AuthToken"] != null;
            var products = await _service.Find();
            return View(products);
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