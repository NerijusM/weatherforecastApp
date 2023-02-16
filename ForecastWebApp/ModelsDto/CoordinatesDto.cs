using System;
using ForecastCore.Entities;
using Newtonsoft.Json;

namespace ForecastWebAppAngular.ModelsDto
{
	public class CoordinatesDto
	{
       
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CoordinatesDto()
		{
		}

        public CoordinatesDto(Coordinates cordinates)
        {
            Latitude = cordinates.Latitude;
            Longitude = cordinates.Longitude;
        }
    }
}

