using Newtonsoft.Json;

namespace ForecastCore.Entities;

public class Place
{
    [JsonProperty("code")]
    public string Code { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; } 
    [JsonProperty("administrativeDivision")]
    public string AdministrativeDivision { get; set; }
    [JsonProperty("country")]
    public string Country { get; set; } 
    [JsonProperty("countryCode")]
    public string CountryCode { get; set; } 
    [JsonProperty("coordinates")]
    public Coordinates Coordinates { get; set; }
}
