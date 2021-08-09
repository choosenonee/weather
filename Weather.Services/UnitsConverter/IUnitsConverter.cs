using api.Domain.Dto;
using api.Domain.Models;
using Weather.Domain.Models;

namespace Weather.Services.UnitsConverter
{
    public interface IUnitsConverter
    {
        WeatherModel ConvertTemperature(WeatherModel valueToConvert, Units unitType);
    }
}
