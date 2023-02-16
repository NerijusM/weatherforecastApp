using System;
using ForecastCore.Entities;
using ForecastWebAppAngular.ModelsDto;

namespace ForecastWebAppAngular.Extensions
{
	public static class ForecasExtensions
	{
		public static ForecastDto ToDto(this Forecast forecast)
		{
			return new ForecastDto(forecast);
		}
    }
}

