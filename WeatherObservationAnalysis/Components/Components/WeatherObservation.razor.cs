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
        public string? stationId { get; set; }
        public string? stationName { get; set; }

        public string? histStationId { get; set; }
        public string? histStationType { get; set; }
        public string? histStationName { get; set; }
        public string? histTimestamp { get; set; }
        public string? tempUnitCode { get; set; }
        public decimal? tempValue { get; set; }
        public Stations result { get; set; } = new();
        public Feature histResult { get; set; } = new();
        public string? station { get; set; }
        public string? timestamp { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetClosestWeatherStation("0007W");
            await GetHistWeatherObservations("0007W");
                
        }

        public async Task<Stations> GetClosestWeatherStation(string location)
        {
            result = await NWSDetailsService.GetClosestWeatherStation(location);

            stationId = result.properties.stationIdentifier;
            stationName = result.properties.name;

            return result;
        }

        public async Task<Feature> GetHistWeatherObservations(string location)
        {
            histResult = await NWSDetailsService.GetHistWeatherObservations(location);

            histStationId = histResult.features[0].id;
            histStationType = histResult.features[0].type;
            station = histResult.features[0].properties.station;
            timestamp = histResult.features[0].properties.timestamp;
 
            return histResult;
        }
    }
}
