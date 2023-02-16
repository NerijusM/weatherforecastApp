using System;
using ForecastCore.Entities;
using ForecastWebAppAngular.ModelsDto;

namespace ForecastWebAppAngular.Extensions
{
	public static class ForecastTimestampExtensions
	{
		public static List<ForecastTimestampDto>
			ToDto(this IEnumerable<ForecastTimestamp> forecastTimestamList)
		{
			return forecastTimestamList
				.Select(stamp => new ForecastTimestampDto(stamp))
				.ToList();
		}
	}
}

