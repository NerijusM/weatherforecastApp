using ForecastCore.Entities;
using ForecastCore.Shared;

namespace ForecastCore.Interfaces
{
    public interface IForecastService: IDisposable
    {
        Task<Result<IEnumerable<Place>>> GetPlaces();
        Task<Result<Forecast>> GetPlaceForecast(string place);
    }
}

