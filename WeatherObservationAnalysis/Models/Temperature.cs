namespace WeatherObservationAnalysis.Models
{
    public class Temperature
    {
        public string unitCode { get; set; } = default!;
        public decimal value { get; set; } = default!;
        public string qualityControl { get; set; } = default!;
    }
}
