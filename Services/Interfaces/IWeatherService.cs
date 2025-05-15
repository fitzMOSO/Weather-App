using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_App.Models;

namespace Weather_App.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherDetail?> GetWeatherAsync(string city, string format);
    }
}
