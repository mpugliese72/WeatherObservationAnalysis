﻿namespace WeatherObservationAnalysis.Models
{
    public class DewPoint
    {
        public string unitCode { get; set; } = default!;
        public decimal value { get; set; } = default!;
        public string qualityControl { get; set; } = default!;
    }
}
