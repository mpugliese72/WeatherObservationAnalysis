namespace WeatherObservationAnalysis.Models
{
    public class Features
    {
        public string? id { get; set; } = default!;
        public string? type { get; set; } = default!;
        public Geometry geometry { get; set; } = new();
        public Properties properties { get; set; } = new();
    }
}
