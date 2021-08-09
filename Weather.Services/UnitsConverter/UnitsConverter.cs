using api.Domain.Models;
using System;
using Weather.Domain.Models;

namespace Weather.Services.UnitsConverter
{
    public class UnitsConverter : IUnitsConverter
    {
        public WeatherModel ConvertTemperature(WeatherModel valueToConvert, Units unitType)
        {
            if(unitType == Units.Imperial)
            {
                return valueToConvert;
            }

            var weatherModelConvertyed = new WeatherModel()
            {
                main = new WeatherModel.Main()
            };

            weatherModelConvertyed.main.feels_like = ToMetric(valueToConvert.main.feels_like);
            weatherModelConvertyed.main.temp = ToMetric(valueToConvert.main.temp);
            weatherModelConvertyed.main.temp_max = ToMetric(valueToConvert.main.temp_max);
            weatherModelConvertyed.main.temp_min = ToMetric(valueToConvert.main.temp_min);
            return weatherModelConvertyed;
        }

        public static float ToMetric(float value)
        {
            return (float)Math.Round(value - 273.15f, 2);
        }
    }
}
