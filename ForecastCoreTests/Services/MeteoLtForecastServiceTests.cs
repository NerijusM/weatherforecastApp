using System;
using System.Net;
using ForecastCore.Interfaces;
using ForecastCore.Services;
using RichardSzalay.MockHttp;
using static System.Net.WebRequestMethods;

namespace ForecastCoreTests.Services;

[TestFixture]
public class MeteoLtForecastServiceTests
{

    private const string placesRespond = @"[
                    {
                        'code': 'abromiskes',
                        'name': 'Abromiškės',
                        'administrativeDivision': 'Elektrėnų savivaldybė',
                        'countryCode': 'LT'
                    },
                    {
                        'code': 'acokavai',
                        'name': 'Acokavai',
                        'administrativeDivision': 'Radviliškio rajono savivaldybė',
                        'countryCode': 'LT'
                    }
                   ]";

    private const string placecode = "vilnius";
    private const string placeForecastRespond =
     @"{
	    'place': {
		    'code': 'vilnius',
		    'name': 'Vilnius',
		    'administrativeDivision': 'Vilniaus miesto savivaldybė',
		    'country': 'Lietuva',
		    'countryCode': 'LT',
		    'coordinates': {
			    'latitude': 54.687046,
			    'longitude': 25.282911
		    }
	    },
	    'forecastType': 'long-term',
	    'forecastCreationTimeUtc': '2023-02-16 10:20:34',
	    'forecastTimestamps': [
		    {
			    'forecastTimeUtc': '2023-02-16 10:00:00',
			    'airTemperature': 1.3,
			    'feelsLikeTemperature': -0.9,
			    'windSpeed': 2,
			    'windGust': 4,
			    'windDirection': 202,
			    'cloudCover': 99,
			    'seaLevelPressure': 1021,
			    'relativeHumidity': 86,
			    'totalPrecipitation': 0,
			    'conditionCode': 'cloudy'
		    },
		    {
			    'forecastTimeUtc': '2023-02-16 11:00:00',
			    'airTemperature': 1.7,
			    'feelsLikeTemperature': -0.5,
			    'windSpeed': 2,
			    'windGust': 5,
			    'windDirection': 212,
			    'cloudCover': 100,
			    'seaLevelPressure': 1021,
			    'relativeHumidity': 82,
			    'totalPrecipitation': 0,
			    'conditionCode': 'cloudy'
		    }
	    ]
    }";

    [Test]
    public void GetPlaces_CommunicationError_ReturFailureResult()
    {
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://api.meteo.lt/v1/places/")
                .Respond(HttpStatusCode.BadRequest);

        IForecastService service = ForecastService(mockHttp);

        var task = service.GetPlaces();
        task.Wait();

        var result = task.Result;

        Assert.That(result.Failure, Is.True);
        Assert.That(result.Error, Does.Contain("Communication error"));
    }

    [Test]
    public void GetPlaces_ContentError_ReturFailureResult()
    {
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://api.meteo.lt/v1/places/")
                .Respond("application/json", "");

        IForecastService service = ForecastService(mockHttp);

        var task = service.GetPlaces();
        task.Wait();

        var result = task.Result;

        Assert.That(result.Failure, Is.True);
        Assert.That(result.Error, Does.Contain("Content error"));
    }

    [Test]
    public void GetPlaces_Data_ReturSuccessResult()
    {
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://api.meteo.lt/v1/places/")
                .Respond("application/json", placesRespond);
     
        IForecastService service = ForecastService(mockHttp);

        var task = service.GetPlaces();
        task.Wait();

        var result = task.Result;

        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public void GetPlaceForecast_CommunicationError_ReturFailureResult()
    {
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://api.meteo.lt/v1/places/vilnius/forecasts/long-term")
                .Respond(HttpStatusCode.BadRequest);

        IForecastService service = ForecastService(mockHttp);

        var task = service.GetPlaceForecast(placecode);
        task.Wait();

        var result = task.Result;

        Assert.That(result.Failure, Is.True);
        Assert.That(result.Error, Does.Contain("Communication error"));
    }

    [Test]
    public void GetPlaceForecast_ContentError_ReturFailureResult()
    {
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://api.meteo.lt/v1/places/vilnius/forecasts/long-term")
                .Respond("application/json", "");

        IForecastService service = ForecastService(mockHttp);

        var task = service.GetPlaceForecast(placecode);
        task.Wait();

        var result = task.Result;

        Assert.That(result.Failure, Is.True);
        Assert.That(result.Error, Does.Contain("Content error"));
    }

    [Test]
    public void GGetPlaceForecast_Data_ReturSuccessResult()
    {
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://api.meteo.lt/v1/places/vilnius/forecasts/long-term")
                .Respond("application/json", placeForecastRespond);

        IForecastService service = ForecastService(mockHttp);

        var task = service.GetPlaceForecast(placecode);
        task.Wait();

        var result = task.Result;

        Assert.That(result.IsSuccess, Is.True);
    }
    private static IForecastService ForecastService(MockHttpMessageHandler mockHttp)
    {
        var client = new HttpClient(mockHttp)
        {
            BaseAddress = new Uri("https://api.meteo.lt/v1/")
        };
        IForecastService service = new MeteoLtForecastService(client);

        return service;
    }
}

