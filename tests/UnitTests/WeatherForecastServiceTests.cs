using Api.Core;
using Xunit;

namespace UnitTests;

public class WeatherForecastServiceTests
{
    WeatherForecastService _weatherForecastService;

    public WeatherForecastServiceTests()
    {
        _weatherForecastService = new WeatherForecastService();        
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(7)]
    public void GetWeatherForecast_ValidForecastingPeriod_ReturnsMatchingForecast(int daysToForecast)
    {
        //Act
        var actual = _weatherForecastService.GenerateForecast(daysToForecast);

        //Assert
        Assert.Equal(daysToForecast, actual.Length);
    }
}

