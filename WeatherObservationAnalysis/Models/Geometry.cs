namespace WeatherObservationAnalysis.Models
{
    public class Geometry
    {
        public string? Type { get; set; }
        public decimal[] Coordinates { get; set; } = default!;
    }
}
