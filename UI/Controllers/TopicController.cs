using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;
using UI.Services;

namespace UI.Controllers;

public class TopicController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITopicService _service;
    public TopicController(ILogger<HomeController> logger, ITopicService service)
    {
        _logger = logger;
        _service = service ?? throw new ArgumentNullException(nameof(service));

    }

    public async Task<IActionResult> Index()
    {
        var products = await _service.Find();
        return View(products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
