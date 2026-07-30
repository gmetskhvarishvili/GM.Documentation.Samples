using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace GM.Documentation.Sample.API.Controllers;

/// <summary>
/// Samples
/// </summary>
[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class Sample1Controller : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    /// <summary>
    /// Get My Weather
    /// </summary>
    /// <returns>List of weather</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}

[ApiVersion("2.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class Sample2Controller : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild"
    ];

    /// <summary>
    /// Get My Weather
    /// </summary>
    /// <returns>List of weather</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}

/// <summary>
/// Weather Forecast Model
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// My date
    /// </summary>
    public DateOnly Date { get; set; }
    
    /// <summary>
    /// My Temperature
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// My Temperature F
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// My Summery
    /// </summary>
    public string? Summary { get; set; }
}