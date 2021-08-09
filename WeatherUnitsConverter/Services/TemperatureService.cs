using api.Services;
using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Weather.Services.UnitsConverter;

namespace WeatherLogger.Service.Services
{
    public class TemperatureService : Temperaturer.TemperaturerBase
    {
        private readonly ILogger<TemperatureService> _logger;
        private readonly IWeatherService _weatherService;
        private readonly IUnitsConverter _unitsConverterService;
        private readonly IMapper _mapper;

        public TemperatureService(ILogger<TemperatureService> logger, IWeatherService weatherService, IUnitsConverter unitsConverterService, IMapper mapper)
        {
            _logger = logger;
            _weatherService = weatherService;
            _mapper = mapper;
            _unitsConverterService = unitsConverterService;
        }

        public override async Task<TemperatureReply> GetTemperature(TemperatureRequest request, ServerCallContext context)
        {
            var weather = await this._weatherService.GetWeather(request.City, CancellationToken.None);
            var temperatureConverted = this._unitsConverterService.ConvertTemperature(weather, Weather.Domain.Models.Units.Metric);
            var temperatureReply = this._mapper.Map<TemperatureReply>(temperatureConverted.main);
            return temperatureReply;
        }

    }
}
