using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KYC.Models;

namespace KYC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [Route("welcome")]
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        return Content($"Hello {name}\nNumTimes: {numTimes}");
    }
}
