using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GhibliCalendar.Models;

namespace GhibliCalendar.Controllers;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
public IActionResult AddEvent(string title, DateTime date)
{
    // Save to database or temporary list (for now, use TempData)
    TempData["Event"] = $"{title} on {date.ToShortDateString()}";
    return RedirectToAction("Index");
}

}
