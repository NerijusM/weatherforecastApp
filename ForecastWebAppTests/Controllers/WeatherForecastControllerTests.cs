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
}

