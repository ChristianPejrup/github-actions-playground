using Api.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WeatherForecastService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/weatherforecast", (WeatherForecastService weatherForecastService) =>
{
    var forecast = weatherForecastService.GenerateForecast(5);

    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
