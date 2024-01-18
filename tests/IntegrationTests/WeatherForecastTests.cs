using Api.Core;
using System.Net;
using Xunit;
namespace IntegrationTests;

public class WeatherForecastTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public WeatherForecastTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData(1)]
    [InlineData(7)]
    public async Task GetWeatherForecast_ReturnsValidListOfForecasts(int daysToForecast)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/weatherforecast?days={daysToForecast}");

        // Assert
        Assert.True(response.IsSuccessStatusCode);
        var forecasts = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();

        Assert.NotNull(forecasts);
        Assert.Equal(daysToForecast, forecasts!.Count);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(8)]
    public async Task GetWeatherForecast_ValidForecastingPeriod_ThrowsAnException(int daysToForecast)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/weatherforecast?days={daysToForecast}");

        // Assert
        Assert.False(response.IsSuccessStatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        
    }
}

