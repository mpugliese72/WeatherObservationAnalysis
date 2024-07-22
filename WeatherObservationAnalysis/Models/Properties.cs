namespace WeatherObservationAnalysis.Models
{
    public class Properties
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public Elevation elevation { get; set; }
        public string? station { get; set; }
        public string? stationIdentifier { get; set; }
        public string? timestamp { get; set; }
        public string? rawMessage { get; set; }
        public string? textDescription { get; set; }
        public string? icon { get; set; }
        public string? name { get; set; }
        public string? timeZone { get; set; }
        public string? forecast { get; set; }
        public string? county { get; set; }
        public string? fireWeatherZone { get; set; }
        public Temperature temperature { get; set; } = new();
        public DewPoint dewPoint { get; set; } = new();
        public WindDirection windDirection { get; set; } = new();
        public WindGust windGust { get; set; } = new();
        public BarometricPressure barometricPressure { get; set; } = new();
        public MaxTemperatureLast24Hours maxTemperatureLast24Hours { get; set; } = new();
        public MinTemperatureLast24Hours minTemperatureLast24Hours { get; set; } = new();
    }
}
