using System.Diagnostics.Metrics;
using WeatherObservationAnalysis.Components.Components;
using Xunit;

namespace WeatherObservationAnalysisTest
{
    public class WeatherObservationAnalysisTest
    {
        [Fact]
        public void GetClosestWeatherStationNull()
        {
            // Arrange
            WeatherObservation weatherObservation = new WeatherObservation();

            // Act
            var result = weatherObservation.GetClosestWeatherStation("");

            // Assert
            Assert.ThrowsAsync<ArgumentException>(() => weatherObservation.GetClosestWeatherStation(""));
        }
    }
}