using api.Domain.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace api.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
        }

        public async Task<WeatherModel> GetWeather(string cityName, CancellationToken token)
        {
            var weatherUri = new UriBuilder(new Uri(this._configuration["WeatherApiUrl"]));
            weatherUri.Query += string.Format("&q={0}", cityName);
            var weatherResponse = await this._httpClient.GetAsync(weatherUri.Uri);
            var weather = await weatherResponse.Content.ReadAsStringAsync();
            var weatherDeserialized = JsonConvert.DeserializeObject<WeatherModel>(weather);
            return weatherDeserialized;
        }
    }
}
