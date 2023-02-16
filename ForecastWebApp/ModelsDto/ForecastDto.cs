using System;
using ForecastCore.Entities;
using Newtonsoft.Json;
using ForecastWebAppAngular.Extensions;

namespace ForecastWebAppAngular.ModelsDto
{
	public class ForecastDto
	{
        public PlaceDto Place { get; set; }
        public string ForecastType { get; set; }
        public string ForecastCreationTimeUtc { get; set; }
        public List<ForecastTimestampDto> ForecastTimestamps { get; set; }

        public ForecastDto(){}

        public ForecastDto(Forecast forecast)
        {
            Place = forecast.Place.ToDto();
            ForecastType = forecast.ForecastType;
            ForecastCreationTimeUtc = forecast.ForecastCreationTimeUtc;
            ForecastTimestamps = forecast.ForecastTimestamps.ToDto();
        }
    }
}

