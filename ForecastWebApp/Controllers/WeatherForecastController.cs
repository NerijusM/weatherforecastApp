using ForecastCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ForecastWebAppAngular.Extensions;

namespace ForecastWebAppAngular.Controllers;

public class WeatherForecastController : BaseApiController
{
    private readonly IForecastService _forecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                     IForecastService forecastService): base (logger)
    {
        _forecastService = forecastService;
    }

    [HttpGet("places")]
    public async Task<IActionResult> Places()
    {
        var result = await _forecastService.GetPlaces();
        if (result.Failure)
            return ReturnErrorResult(result);

        return Ok(result.Value.ToDto());
    }

    [HttpGet("forecast")]
    public async Task<IActionResult> Forecast(string place)
    {
        var result = await _forecastService.GetPlaceForecast(place);
        if (result.Failure) return
                ReturnErrorResult(result);
        return Ok(result.Value.ToDto());
    }
}

