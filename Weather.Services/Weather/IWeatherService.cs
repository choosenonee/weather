using api.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace api.Services
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetWeather(string cityName, CancellationToken token);
    }
}
