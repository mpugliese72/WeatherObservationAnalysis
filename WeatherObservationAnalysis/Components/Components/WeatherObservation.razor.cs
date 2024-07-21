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
        public string? histStationName { get; set; }
        public string? tempUnitCode { get; set; }
        public decimal? tempValue { get; set; }

        public Stations result { get; set; } = new();
        public Features histResult { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            //await GetClosestWeatherStation("0007W");
            await GetHistWeatherObservations("0007W");
                //"2024-07-19T00:00:00-00:00","2024-07-20T00:00:00-00:00", 10);
        }

        public async Task<Stations> GetClosestWeatherStation(string location)
        {
            result = await NWSDetailsService.GetClosestWeatherStation(location);

            stationId = result.properties.stationIdentifier;
            stationName = result.properties.name;

            return result;
        }

        public async Task<Features> GetHistWeatherObservations(string location)
        {
            histResult = await NWSDetailsService.GetHistWeatherObservations(location);

            //Stations histResults = new Stations();
            //histResults = result;

            histStationId = histResult.properties.stationIdentifier;
            histStationName = histResult.properties.name;
            tempUnitCode = histResult.properties.temperature.unitCode;
            tempValue = histResult.properties.temperature.value;

            return histResult;
        }
    }
}
