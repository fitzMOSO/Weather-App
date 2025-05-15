using System.Text.Json.Serialization;

namespace Weather_App.Models
{
    public class JsonWeatherDetail
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("coord")]
        public JsonCoord? Coord { get; set; }

        [JsonPropertyName("main")]
        public JsonMain? Main { get; set; }

        [JsonPropertyName("weather")]
        public List<JsonWeather> Weather { get; set; }

        [JsonPropertyName("wind")]
        public JsonWind? Wind { get; set; }

        [JsonPropertyName("clouds")]
        public JsonClouds? Clouds { get; set; }

        [JsonPropertyName("sys")]
        public JsonSys? Sys { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("base")]
        public string? Base { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }

    public class JsonCoord
    {
        [JsonPropertyName("lon")]
        public float Lon { get; set; }

        [JsonPropertyName("lat")]
        public float Lat { get; set; }
    }

    public class JsonMain
    {
        [JsonPropertyName("temp")]
        public float Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public float TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public float TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int? SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public int? GroundLevel { get; set; }
    }

    public class JsonWeather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string? Main { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }

    public class JsonWind
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Deg { get; set; }

        [JsonPropertyName("gust")]
        public float? Gust { get; set; }
    }

    public class JsonClouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }

    public class JsonSys
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
    }
}
