using api.Domain.Dto;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Weather.Domain.Models;
using Weather.Services.UnitsConverter;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IUnitsConverter _unitsConverterService;
        private readonly IMapper _mapper;

        public TemperatureController(IWeatherService weatherService, IUnitsConverter unitsConverterService, IMapper mapper)
        {
            this._weatherService = weatherService;
            this._unitsConverterService = unitsConverterService;
            this._mapper = mapper;
        }

        [HttpGet("city")]
        [ProducesResponseType(typeof(TemperatureDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TemperatureDto>> Get([Required][FromQuery] string city, [FromQuery] Units unit = Units.Metric)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return this.BadRequest("City cannot be empty");
            }

            var weather = await this._weatherService.GetWeather(city, CancellationToken.None);
            var weatherConverted = this._unitsConverterService.ConvertTemperature(weather, unit);
            var temperature = this._mapper.Map<TemperatureDto>(weatherConverted.main);
            return this.Ok(temperature);
        }
    }
}