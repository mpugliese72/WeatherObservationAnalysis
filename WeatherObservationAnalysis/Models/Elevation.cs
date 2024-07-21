namespace WeatherObservationAnalysis.Models
{
    public class Elevation
    {
        public string geometry { get; set; } = default!;
        public string unitCode { get; set; } = default!;
        public decimal value { get;set; } = default!;
        public decimal maxValue { get; set; } = default!;
        public decimal minValue { get; set; } = default!;
    }
}
