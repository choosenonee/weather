using api.Domain.Dto;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Weather.Domain.Models;
using Weather.Services.UnitsConverter;

namespace api.Controllers
{
    /*
     * http://localhost:64843/api/Temperature/Szczecin&unit=Metric?api-version=1.0
     * http://localhost:64843/api/Temperature/Szczecin&unit=Metric?api-version=2.0
     * http://localhost:64843/api/Temperature/Szczecin&unit=Metric?api-version=3.0
     */

    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
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

        [HttpGet("{city}")]
        [HttpHead]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(TemperatureDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TemperatureDto>> Get10([Required] string city, [FromQuery] Units unit = Units.Metric)
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

        [HttpGet("{city}")]
        [HttpHead]
        [MapToApiVersion("2.0")]
        [ProducesResponseType(typeof(TemperatureDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TemperatureDto>> Get20([Required] string city, [FromQuery] Units unit = Units.Metric)
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

        [HttpGet("{city}")]
        [HttpHead]
        [MapToApiVersion("3.0")]
        [ProducesResponseType(typeof(TemperatureDto), (int)HttpStatusCode.OK)]
        public ActionResult<TemperatureDto> GetOld([Required] string city, [FromQuery] Units unit = Units.Metric)
        {
            return this.NoContent();
        }
    }
}