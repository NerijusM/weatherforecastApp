using System;
using ForecastCore.Entities;
using ForecastCore.Interfaces;
using ForecastCore.Shared;
using ForecastWebAppAngular.Controllers;
using ForecastWebAppAngular.Extensions;
using ForecastWebAppAngular.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
namespace ForecastWebAppTests.Controllers;

[TestFixture]
public class WeatherForecastControllerTests
{
    private IEnumerable<Place> _placesList = new List<Place>()
    {
        new Place() { Code = "0", Name = "" },
        new Place() { Code = "1", Name = "" },
    };

    private const string placeCode = "kaunas";

    private Forecast forecast = new Forecast()
    {
        ForecastCreationTimeUtc = "2023-02-17 04:20:44",
        Place = new Place()
        {
            Code = "vilnius",
            Name = "Vilnius",
            AdministrativeDivision = "Vilniaus miesto savivaldybė",
            Country = "Lietuva",
            CountryCode = "LT",
            Coordinates = new Coordinates()
            {
                Latitude = 54.687046,
                Longitude = 25.282911
            }
        },
         ForecastType = "long-term",
         ForecastTimestamps = new List<ForecastTimestamp>()
         {
             new ForecastTimestamp()
             {
                ForecastTimeUtc = "2023-02-17 04:00:00",
                AirTemperature = 0,
                FeelsLikeTemperature = -2.4,
                WindSpeed = 2,
                WindGust = 4,
                WindDirection = 179,
                CloudCover = 100,
                SeaLevelPressure = 1016,
                RelativeHumidity = 95,
                TotalPrecipitation = 0,
                ConditionCode = "cloudy"
             }
         }
    };

    [Test]
    public void Places_ResultFailure_ReturStatusCode500()
    {
        var mockService = new Mock<IForecastService>();
        mockService.Setup(service => service.GetPlaces())
            .ReturnsAsync(Result.Fail<IEnumerable<Place>>("Error"));

        var mockLogger =
            new Mock<ILogger<WeatherForecastController>>();


        var controller =
            new WeatherForecastController(mockLogger.Object,
                                          mockService.Object);

        var task = controller.Places();

        task.Wait();

        IActionResult actionResult = task.Result;

        var statusCodeResult = actionResult as StatusCodeResult;

        Assert.That(actionResult, Is.InstanceOf<Microsoft.AspNetCore.Mvc.StatusCodeResult>());
        Assert.That(statusCodeResult, Is.Not.Null);
        Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
    }

    [Test]
    public void Places_ResultOk_ReturStatusCodeOk()
    {
        var mockService = new Mock<IForecastService>();
        mockService.Setup(service => service.GetPlaces())
            .ReturnsAsync(Result.Success<IEnumerable<Place>>(_placesList));

        var mockLogger =
            new Mock<ILogger<WeatherForecastController>>();


        var controller =
            new WeatherForecastController(mockLogger.Object,
                                          mockService.Object);

        var task = controller.Places();

        task.Wait();

        var result = task.Result;

        var okResult = task.Result as OkObjectResult;

        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult?.StatusCode, Is.EqualTo(200));
    }


    [Test]
    public void Forecast_ResultFailure_ReturStatusCode500()
    {
        var mockService = new Mock<IForecastService>();
        mockService.Setup(service => service.GetPlaceForecast(placeCode))
            .ReturnsAsync(Result.Fail<Forecast>("Error"));

        var mockLogger =
            new Mock<ILogger<WeatherForecastController>>();


        var controller =
            new WeatherForecastController(mockLogger.Object,
                                          mockService.Object);

        var task = controller.Forecast(placeCode);

        task.Wait();

        IActionResult actionResult = task.Result;

        var statusCodeResult = actionResult as StatusCodeResult;

        Assert.That(actionResult, Is.InstanceOf<Microsoft.AspNetCore.Mvc.StatusCodeResult>());
        Assert.That(statusCodeResult, Is.Not.Null);
        Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
    }

    [Test]
    public void Forecast_ResultOk_ReturStatusCodeOk()
    {
        var mockService = new Mock<IForecastService>();
        mockService.Setup(service => service.GetPlaceForecast(placeCode))
            .ReturnsAsync(Result.Success<Forecast>(forecast));

        var mockLogger =
            new Mock<ILogger<WeatherForecastController>>();


        var controller =
            new WeatherForecastController(mockLogger.Object,
                                          mockService.Object);

        var task = controller.Forecast(placeCode);

        task.Wait();

        var result = task.Result;

        var okResult = task.Result as OkObjectResult;

        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult?.StatusCode, Is.EqualTo(200));
    }
}

