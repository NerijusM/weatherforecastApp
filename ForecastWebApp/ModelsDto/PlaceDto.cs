using System;
using ForecastCore.Entities;
using Newtonsoft.Json;

namespace ForecastWebAppAngular.ModelsDto
{
	public class PlaceDto
	{
        public string Code { get; set; } //= string.Empty;
        public string Name { get; set; } //= string.Empty;
        public string AdministrativeDivision { get; set; } //= string.Empty;
        public string CountryCode { get; set; } //= string.Empty;

        public PlaceDto()
        {
           
        }

        public PlaceDto(Place place)
		{
            Code = place.Code;
            Name = place.Name;
            AdministrativeDivision = place.AdministrativeDivision;
            CountryCode = place.CountryCode;
		}

	}
}

