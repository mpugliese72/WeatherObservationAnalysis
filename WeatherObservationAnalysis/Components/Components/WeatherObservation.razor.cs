using Microsoft.AspNetCore.Components;
using WeatherObservationAnalysis.Models;
using WeatherObservationAnalysis.Services;

namespace WeatherObservationAnalysis.Components.Components
{
    public partial class WeatherObservation
    {
        [Inject]
        NWSDetailsService NWSDetailsService { get; set; } = default!;
        public HttpClient? HttpClient { get; set; }

        public string? test { get; set; }
        public WeatherStation result { get; set; } = default!;
        protected override async Task OnInitializedAsync()
        {
            //test = "This is a test value";
            await GetClosestWeatherStation("0007W");
        }

        public async Task<WeatherStation> GetClosestWeatherStation(string location)
        {
            result = await NWSDetailsService.GetClosestWeatherStation(location);

            return result;
        }
    }
}
