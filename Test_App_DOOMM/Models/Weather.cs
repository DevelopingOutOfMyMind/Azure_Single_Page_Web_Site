using System.Text.Json.Serialization;

namespace Test_App_DOOMM.Models
{
    // Classes to deserialize the JSON response from weather.gov API

    public class WeatherForecastResponse
    {
        [JsonPropertyName("properties")]
        public ForecastProperties? Properties { get; set; }
    }

    public class ForecastProperties
    {
        [JsonPropertyName("periods")]
        public ForecastPeriod[]? Periods { get; set; }
    }

    public class ForecastPeriod
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }

        [JsonPropertyName("isDaytime")]
        public bool IsDaytime { get; set; }

        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }

        [JsonPropertyName("temperatureUnit")]
        public string? TemperatureUnit { get; set; }

        [JsonPropertyName("windSpeed")]
        public string? WindSpeed { get; set; }

        [JsonPropertyName("windDirection")]
        public string? WindDirection { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("shortForecast")]
        public string? ShortForecast { get; set; }

        [JsonPropertyName("detailedForecast")]
        public string? DetailedForecast { get; set; }
    }

    // Classes to deserialize the initial points lookup
    public class PointProperties
    {
        [JsonPropertyName("forecast")]
        public string? ForecastUrl { get; set; }
    }

    public class PointResponse
    {
        [JsonPropertyName("properties")]
        public PointProperties? Properties { get; set; }
    }
}