using System;
using ForecastCore.Entities;
using ForecastWebAppAngular.ModelsDto;

namespace ForecastWebAppAngular.Extensions
{
	public static class PlaceExtensions
	{
		public static IEnumerable<PlaceDto> ToDto(this IEnumerable<Place> placeList)
		{
			return placeList.Select(place => new PlaceDto(place));
		}

        public static PlaceDto ToDto(this Place place)
        {
            return new PlaceDto(place);
        }
    }
}
