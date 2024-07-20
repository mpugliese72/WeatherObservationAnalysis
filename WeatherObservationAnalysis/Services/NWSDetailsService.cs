//using Microsoft.AspNetCore.Components;

using Microsoft.AspNetCore.Authentication;
using System.Linq;
using WeatherObservationAnalysis.Models;

namespace WeatherObservationAnalysis.Services
{
    public class NWSDetailsService
    {
        private IConfiguration configuration { get; set; } = default!;

        private readonly HttpClient? httpClient;
        private string? closestWeatherStationURL { get; set; }
        private string? BaseUrl { get; set; }

        public NWSDetailsService(HttpClient _httpClient, IConfiguration _configuration)
        {
            this.httpClient = _httpClient;
            this.configuration = _configuration;

            BaseUrl = configuration.GetValue<string>("NWSAPI:BaseUrl");

            this.closestWeatherStationURL = $"{BaseUrl}stations/";
        }

        public async Task<WeatherStation> GetClosestWeatherStation(string location)
        {
            //HttpRequest request = null;

            //var test = request?.Headers.UserAgent.ToString();
            
            //var test2 = request?.Headers.GetCommaSeparatedValues("User-Agent");

            using HttpResponseMessage response =
                await httpClient.GetAsync(closestWeatherStationURL + location);

            //response.EnsureSuccessStatusCode();

            var results = await response.Content.ReadFromJsonAsync<WeatherStation>();
            return results;
        }
    }
}
