using System.Net.Http.Headers;
using System.Net.Http.Json;
using Test_App_DOOMM.Models;

namespace Test_App_DOOMM.Services
{
    public class WeatherService
    {
        // Feature flag for logging
        public static bool EnableDebugLogging { get; set; } = true;

        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Set User-Agent header required by weather.gov
            if (!_httpClient.DefaultRequestHeaders.UserAgent.Any())
            {
                _httpClient.DefaultRequestHeaders.UserAgent.Add(
                    new ProductInfoHeaderValue("Test_App_DOOMM", "1.0"));
            }
        }

        public async Task<ForecastPeriod[]?> GetWeatherForZipAsync(string zipCode)
        {
            try
            {
                var lat = "28.1436";
                var lon = "-82.5662"; // Approximate for 33558

                var pointUrl = $"https://api.weather.gov/points/{lat},{lon}";
                if (EnableDebugLogging)
                    Console.WriteLine($"Fetching point data from: {pointUrl}");

                var pointResponse = await _httpClient.GetFromJsonAsync<PointResponse>(pointUrl);

                if (pointResponse?.Properties?.ForecastUrl == null)
                {
                    if (EnableDebugLogging)
                        Console.WriteLine("Failed to get forecast URL from point response.");
                    return null;
                }

                if (EnableDebugLogging)
                    Console.WriteLine($"Fetching forecast from: {pointResponse.Properties.ForecastUrl}");

                var forecastResponse = await _httpClient.GetFromJsonAsync<WeatherForecastResponse>(pointResponse.Properties.ForecastUrl);

                if (forecastResponse?.Properties?.Periods == null)
                {
                    if (EnableDebugLogging)
                        Console.WriteLine("No forecast periods found in forecast response.");
                    return null;
                }

                if (EnableDebugLogging)
                    Console.WriteLine("Successfully fetched weather forecast.");
                return forecastResponse.Properties.Periods;
            }
            catch (Exception ex)
            {
                if (EnableDebugLogging)
                    Console.WriteLine($"Error fetching weather data: {ex.Message}");
                return null;
            }
        }
    }
}