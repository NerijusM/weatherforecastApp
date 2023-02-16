using ForecastCore.Entities;
using ForecastCore.Interfaces;
using ForecastCore.Shared;
using Newtonsoft.Json;

namespace ForecastCore.Services;

public class MeteoLtForecastService : IForecastService
{
	private readonly HttpClient _httpClient;

    public MeteoLtForecastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Result<IEnumerable<Place>>> GetPlaces()
	{
        try
        {
            using var response = await _httpClient.GetAsync("places/");
            if (!response.IsSuccessStatusCode)
            {
                return Result.Fail<IEnumerable<Place>>($"Communication error: with status code {response.StatusCode}");
            }
            return await DeserializePlaceResponse(response);
        }
        catch (Exception ex)
        {
            return Result.Fail<IEnumerable<Place>>($"Error: {ex.Message}");
        }
	}

    public async Task<Result<Forecast>> GetPlaceForecast(string place)
    {
        try
        {
            using var response = await _httpClient.GetAsync($"places/{place}/forecasts/long-term");
            if (!response.IsSuccessStatusCode)
            {
                return Result.Fail<Forecast>($"Communication error: with status code {response.StatusCode}");
            }
            return await DeserializeForecastResponse(response);
        }
        catch (Exception ex)
        {
            return Result.Fail<Forecast>($"Error: {ex.Message}");
        }
    }

    public void Dispose() => _httpClient?.Dispose();

    private static async Task<Result<Forecast>> DeserializeForecastResponse(HttpResponseMessage response)
    {
        var jsonstring = await response.Content.ReadAsStringAsync();
        var forecastist = JsonConvert.DeserializeObject<Forecast>(jsonstring);
        if (forecastist == null)
        {
            return Result.Fail<Forecast>("Content error: No data where serialized");
        }
        return Result.Success(forecastist);
    }

    private static async Task<Result<IEnumerable<Place>>> DeserializePlaceResponse(HttpResponseMessage response)
    {
        var jsonstring = await response.Content.ReadAsStringAsync();
        var placeList = JsonConvert.DeserializeObject<IEnumerable<Place>>(jsonstring);
        if (placeList == null)
        {
            return Result.Fail<IEnumerable<Place>>("Content error: No data where serialized");
        }
        return Result.Success(placeList);
    }
}
