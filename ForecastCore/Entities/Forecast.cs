using Newtonsoft.Json;

namespace ForecastCore.Entities;

public class Forecast
{
    [JsonProperty("place")]
    public Place Place { get; set; }
    [JsonProperty("forecastType")]
    public string ForecastType { get; set; }
    [JsonProperty("forecastCreationTimeUtc")]
    public string ForecastCreationTimeUtc { get; set; }
    [JsonProperty("forecastTimestamps")]
    public List<ForecastTimestamp> ForecastTimestamps { get; set; }
}