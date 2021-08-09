using Grpc.Net.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherLogger.Service;

namespace WWeatherLogger.Client
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Temperaturer.TemperaturerClient(channel);
            
            while (!stoppingToken.IsCancellationRequested)
            {
                var reply = await client.GetTemperatureAsync(new TemperatureRequest { City = "Warsaw", Unit = Units.M }, deadline: DateTime.Now.AddSeconds(1));
                //Console.WriteLine("Greeting: " + reply.Message);
                _logger.LogInformation("Temperature:" + reply.Temperature, DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
