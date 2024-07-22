namespace WeatherObservationAnalysis.Models
{
    public class Elevation
    {
        public string? geometry { get; set; }
        public string? unitCode { get; set; }
        public decimal? value { get;set; }
        public decimal? maxValue { get; set; }
        public decimal? minValue { get; set; }
    }
}
