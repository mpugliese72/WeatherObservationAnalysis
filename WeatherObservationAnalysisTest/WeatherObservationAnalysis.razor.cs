using System.Diagnostics.Metrics;
using WeatherObservationAnalysis.Components.Components;
using Xunit;

namespace WeatherObservationAnalysisTest
{
    public class WeatherObservationAnalysisTest
    {
        [Fact]
        public void GetClosestWeatherStationIncorrectValue()
        {
            // Arrange
            WeatherObservation weatherObservation = new WeatherObservation();

            // Act
            var result = weatherObservation.GetClosestWeatherStation("987654");
            
            // Assert
            if (result == null)
            {
                var message = "No results for inputted weather station";
                Assert.Fail(string.Format(message, result));
            }
        }

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