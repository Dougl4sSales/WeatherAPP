using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Data;

namespace WeatherApp.Services
{
    public class WeatherBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string[] _capitais = new[]
        {
            "São Paulo", "Rio de Janeiro", "Belo Horizonte", "Salvador", "Brasília", 
            "Fortaleza", "Curitiba", "Manaus", "Recife", "Porto Alegre"
        };

        public WeatherBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var weatherService = scope.ServiceProvider.GetRequiredService<WeatherService>();

                    foreach (var city in _capitais)
                    {
                        try
                        {
                            await weatherService.GetWeatherAsync(city);
                        }
                        catch (Exception ex)
                        {                            
                            Console.WriteLine($"Erro ao consultar clima de {city}: {ex.Message}");
                        }
                    }
                }

                // Aguarda 15 minutos
                // await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
            }
        }
    }
}
