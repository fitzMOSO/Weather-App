using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Weather_App.Models
{
    [XmlRoot("current")]
    public class WeatherDetail
    {
        // City Info
        [JsonPropertyName("name")]
        [XmlElement("city")]
        public string CityName { get; set; }

        [JsonPropertyName("id")]
        [XmlAttribute("id")]
        public int CityId { get; set; }

        // Coordinates
        [JsonPropertyName("coord")]
        [XmlElement("coord")]
        public Coord Coord { get; set; }

        // Country
        [JsonPropertyName("sys")]
        [XmlElement("country")]
        public string Country { get; set; }

        // Main Weather Data
        [JsonPropertyName("main")]
        [XmlElement("temperature")]
        public MainWeather Main { get; set; }

        [JsonPropertyName("weather")]
        [XmlElement("weather")]
        public List<WeatherDescription> Weather { get; set; }

        [JsonPropertyName("wind")]
        [XmlElement("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("clouds")]
        [XmlElement("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("dt")]
        [XmlElement("lastupdate")]
        public long DateTimeUnix { get; set; }

        [JsonPropertyName("timezone")]
        [XmlElement("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("visibility")]
        [XmlElement("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("pressure")]
        [XmlElement("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        [XmlElement("humidity")]
        public int Humidity { get; set; }
    }

    public class Coord
    {
        [JsonPropertyName("lon")]
        [XmlAttribute("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("lat")]
        [XmlAttribute("lat")]
        public double Lat { get; set; }
    }

    public class MainWeather
    {
        [JsonPropertyName("temp")]
        [XmlAttribute("value")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        [XmlAttribute("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        [XmlAttribute("min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        [XmlAttribute("max")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        [XmlAttribute("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        [XmlAttribute("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherDescription
    {
        [JsonPropertyName("id")]
        [XmlAttribute("number")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        [XmlAttribute("value")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        [XmlAttribute("value")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        [XmlAttribute("icon")]
        public string Icon { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        [XmlElement("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        [XmlElement("direction")]
        public int Deg { get; set; }

        [JsonPropertyName("gust")]
        [XmlElement("gusts")]
        public double Gust { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        [XmlAttribute("value")]
        public int All { get; set; }

        [JsonPropertyName("name")]
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
