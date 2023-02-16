using System;
using System.Data.SqlTypes;
using ForecastCore.Entities;
using Newtonsoft.Json;

namespace ForecastWebAppAngular.ModelsDto
{
	public class ForecastTimestampDto
    {
        private const string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public string ForecastTimeUtc { get; set; }
        public double AirTemperature { get; set; }
        public double FeelsLikeTemperature { get; set; }
        public int WindSpeed { get; set; }
        public int WindGust { get; set; }
        public int WindDirection { get; set; }
        public int CloudCover { get; set; }
        public int SeaLevelPressure { get; set; }
        public int RelativeHumidity { get; set; }
        public double TotalPrecipitation { get; set; }
        public string ConditionCode { get; set; }

        public string ForecastLocalTime { get; } 

        public ForecastTimestampDto()
		{
		}

        public ForecastTimestampDto(ForecastTimestamp forecastTimestamp)
        {
            ForecastTimeUtc = forecastTimestamp.ForecastTimeUtc;
            AirTemperature = forecastTimestamp.AirTemperature;
            FeelsLikeTemperature = forecastTimestamp.FeelsLikeTemperature;
            WindSpeed = forecastTimestamp.WindSpeed;
            WindGust = forecastTimestamp.WindGust;
            WindDirection = forecastTimestamp.WindDirection;
            CloudCover = forecastTimestamp.CloudCover;
            SeaLevelPressure = forecastTimestamp.SeaLevelPressure;
            RelativeHumidity = forecastTimestamp.RelativeHumidity;
            TotalPrecipitation = forecastTimestamp.TotalPrecipitation;
            ConditionCode = forecastTimestamp.ConditionCode;

            ForecastLocalTime = ForecastTimeLocal();
        }

        private string ForecastTimeLocal()
        {
            try
            {
                var utc = DateTime.Parse(ForecastTimeUtc);
                return utc.ToLocalTime().ToString(dateTimeFormat);

            }
            catch
            {
                return string.Empty;
            }
        }
    }
}

