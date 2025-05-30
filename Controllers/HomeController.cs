using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Weather_App.Models;
using Weather_App.Services.Interface;
using Weather_App.ViewModel;

namespace Weather_App.Controllers;

public class HomeController(ILogger<HomeController> logger, IWeatherService weatherService)
    : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index() => View();

    public IActionResult Privacy() => View();

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
        var weatherData = await weatherService.GetWeatherAsync(city, format);
        var viewModel = new HomeIndexViewModel { WeatherData = weatherData, DataFormat = format };
        return PartialView("_WeatherResult", viewModel);
    }

    public IActionResult GetRawWeather()
    {
        throw new NotImplementedException();
    }
}
