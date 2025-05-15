using System.Text.Json;
using System.Xml.Serialization;
using Weather_App.Models;
using Weather_App.Services.Interfaces;

namespace Weather_App.Services
{
    public class WeatherService(IConfiguration configuration) : IWeatherService
    {
        private readonly HttpClient _httpClient = new();
        private readonly string _apiKey =
            configuration["OpenWeatherMap:ApiKey"]
            ?? throw new ArgumentNullException(nameof(configuration));
        private readonly string _baseUrl =
            configuration["OpenWeatherMap:BaseUrl"]
            ?? throw new ArgumentNullException(nameof(configuration));

        public async Task<WeatherDetail?> GetWeatherAsync(string city, string format)
        {
            var url =
                format == "json"
                    ? $"{_baseUrl}q={city}&appid={_apiKey}"
                    : $"{_baseUrl}q={city}&appid={_apiKey}&mode={format}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();

            if (format == "json")
            {
                return JsonSerializer.Deserialize<WeatherDetail>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }
            else if (format == "xml")
            {
                var serializer = new XmlSerializer(typeof(WeatherDetail));
                using var reader = new StringReader(content);
                return serializer.Deserialize(reader) as WeatherDetail;
            }

            return null;
        }
    }
}
