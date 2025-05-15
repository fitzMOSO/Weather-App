using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Weather_App.Models;
using Weather_App.Services.Interface;

namespace Weather_App.Services
{
    public class WeatherService(IConfiguration configuration) : IWeatherService
    {
        private readonly HttpClient _httpClient = new();
        private readonly string _apiKey =
            configuration["OpenWeatherMap:ApiKey"]
            ?? throw new ArgumentNullException(
                nameof(configuration),
                "OpenWeatherMap:ApiKey is not configured"
            );
        private readonly string _baseUrl =
            configuration["OpenWeatherMap:BaseUrl"]
            ?? throw new ArgumentNullException(
                nameof(configuration),
                "OpenWeatherMap:BaseUrl is not configured"
            );
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        private readonly XmlSerializer _xmlSerializer = new(typeof(XMLWeatherDetail));

        // Initialize JSON options
        // Initialize XML serializer

        public async Task<object?> GetWeatherAsync(string city, string format)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City name cannot be empty", nameof(city));

            // Build the URL with proper encoding
            var encodedCity = Uri.EscapeDataString(city);
            var url =
                format == "json"
                    ? $"{_baseUrl}q={encodedCity}&appid={_apiKey}&units=metric"
                    : $"{_baseUrl}q={encodedCity}&mode={format}&appid={_apiKey}&units=metric";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
                throw new InvalidOperationException("Received empty response from weather service");

            // Check the format and deserialize accordingly
            if (format == "json")
            {
                // Simple check: does it contain a "main" or "weather" property?
                if (!content.Contains("\"main\"") && !content.Contains("\"weather\""))
                {
                    // Not a valid weather response
                    return null;
                }
                return DeserializeJson(content);
            }
            else
            {
                return DeserializeXml(content);
            }
        }

        private JsonWeatherDetail? DeserializeJson(string content)
        {


            return JsonSerializer.Deserialize<JsonWeatherDetail>(content, _jsonOptions);
        }

        private XMLWeatherDetail? DeserializeXml(string content)
        {
            var reader = new StringReader(content);
            return _xmlSerializer.Deserialize(reader) as XMLWeatherDetail;
        }
    }
}
