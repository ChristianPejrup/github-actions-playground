namespace Api.Core;

public class WeatherForecastService
{
    string[] summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    public WeatherForecast[] GenerateForecast(int daysToForecast)
    {
        if(daysToForecast is < 1 or > 14)
        {
            throw new CustomArgumentException("Cannot forecast less than 1 day and more than 14 days");
        }

        var forecast = Enumerable.Range(1, daysToForecast).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            )).ToArray();

        return forecast;
    }
}

