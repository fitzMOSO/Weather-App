using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Weather_App.Models;
using Weather_App.Services.Interfaces;

namespace Weather_App.Controllers;

public class HomeController(ILogger<HomeController> logger, IWeatherService weatherService)
    : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

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
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }

    [HttpPost]
    public async Task<IActionResult> GetWeather(string city, string format)
    {
        var weather = await weatherService.GetWeatherAsync(city, format);

        if (weather == null)
        {
            ViewData["WeatherData"] = "No data found or error retrieving weather.";
        }
        else
        {
            // For now, just show the raw data as JSON or XML string
            if (format == "json")
            {
                ViewData["WeatherData"] = weather;
            }
            else // xml
            {
                ViewData["WeatherData"] = weather;
            }
        }

        return View("Index");
    }
}
