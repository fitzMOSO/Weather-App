using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_App.Models;

namespace Weather_App.Services.Interface
{
    public interface IWeatherService
    {
        Task<object?> GetWeatherAsync(string city, string format);
    }
}
