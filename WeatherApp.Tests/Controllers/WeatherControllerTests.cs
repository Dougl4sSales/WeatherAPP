using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using WeatherApp.Services;
using WeatherApp.Data;
using WeatherApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WeatherApp.Tests.Services
{
    public class WeatherServiceTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetWeatherAsync_SavesDataToDatabase()
        {
            var context = GetDbContext();
            var service = new WeatherService(context);

            var city = "Curitiba";

            var data = await service.GetWeatherAsync(city);
            var saved = context.Weather.FirstOrDefault(w => w.City == city);

            Assert.NotNull(saved);
            Assert.Equal(city, saved.City);
            Assert.Equal(data.Description, saved.Description);
        }

        [Fact]
        public void GetHistory_ReturnsCorrectData()
        {
            
            var context = GetDbContext();
            var service = new WeatherService(context);
            var now = DateTime.Now;

            context.Weather.AddRange(
                new WeatherData { City = "Curitiba", Date = now.AddDays(-2), Temperatura = 20 },
                new WeatherData { City = "Curitiba", Date = now, Temperatura = 25 },
                new WeatherData { City = "São Paulo", Date = now, Temperatura = 22 }
            );
            context.SaveChanges();

            var result = service.GetHistory("Curitiba", now.AddDays(-3), now.AddDays(1)).ToList();

            Assert.Equal(2, result.Count);
            Assert.All(result, r => Assert.Equal("Curitiba", r.City));
        }
    }
}
