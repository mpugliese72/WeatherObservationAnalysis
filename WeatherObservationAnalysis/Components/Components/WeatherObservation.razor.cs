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
        public Stations results { get; set; } = new();
        public Feature histResults { get; set; } = new();
        public string? station { get; set; }
        public string? timestamp { get; set; }
        public string? unitCode { get; set; }
        public decimal? value { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetClosestWeatherStation("0007W");
            await GetHistWeatherObservations("0007W");
        }

        public async Task<Stations> GetClosestWeatherStation(string location)
        {
            results = await NWSDetailsService.GetClosestWeatherStation(location);

            stationId = results.properties.stationIdentifier;
            stationName = results.properties.name;

            return results;
        }

        public async Task<Feature> GetHistWeatherObservations(string location)
        {
            histResults = await NWSDetailsService.GetHistWeatherObservations(location);

            station = histResults.features[0].properties.station;
            timestamp = histResults.features[0].properties.timestamp;
            unitCode = histResults.features[0].properties.maxTemperatureLast24Hours.unitCode;
            value = histResults.features[0].properties.maxTemperatureLast24Hours.value;

            if (value == null)
            {
                value = 0;
            }

            return histResults;
        }
    }
}
