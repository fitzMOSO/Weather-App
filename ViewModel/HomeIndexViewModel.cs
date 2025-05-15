using Weather_App.Models;

namespace Weather_App.ViewModel
{
    public class HomeIndexViewModel
    {
        // For storing the original deserialized model
        public object? WeatherData { get; set; }

        // Flag to identify which format we have
        public string DataFormat { get; set; } = "xml";

        // For XML format
        public XMLWeatherDetail? XmlWeatherDetail => WeatherData as XMLWeatherDetail;

        // For JSON format
        public JsonWeatherDetail? JsonWeatherDetail => WeatherData as JsonWeatherDetail;

        // Helper properties to access data regardless of format
        public string? CityName =>
            DataFormat == "json" ? JsonWeatherDetail?.Name : XmlWeatherDetail?.City?.Name;

        public int? CityId =>
            DataFormat == "json" ? JsonWeatherDetail?.Id : XmlWeatherDetail?.City?.Id;

        public string? Country =>
            DataFormat == "json"
                ? JsonWeatherDetail?.Sys?.Country
                : XmlWeatherDetail?.City?.Country;

        public float? Temperature =>
            DataFormat == "json"
                ? JsonWeatherDetail?.Main?.Temp
                : XmlWeatherDetail?.Temperature?.Value;

        public float? FeelsLikeTemp =>
            DataFormat == "json"
                ? JsonWeatherDetail?.Main?.FeelsLike
                : XmlWeatherDetail?.FeelsLike?.Value;

        public int? Humidity =>
            DataFormat == "json"
                ? JsonWeatherDetail?.Main?.Humidity
                : XmlWeatherDetail?.Humidity?.Value;

        public int? Pressure =>
            DataFormat == "json"
                ? JsonWeatherDetail?.Main?.Pressure
                : XmlWeatherDetail?.Pressure?.Value;

        public string? WeatherDescription =>
            DataFormat == "json"
                ? JsonWeatherDetail?.Weather?.FirstOrDefault()?.Description
                : XmlWeatherDetail?.Weather?.Value;
    }
}
