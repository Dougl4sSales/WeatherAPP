using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Controllers;
using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp.Tests.Controllers
{
    public class WeatherControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewWithData()
        {
            
            var city = "Curitiba";
            var mockService = new Mock<WeatherService>(null);
            mockService.Setup(s => s.GetWeatherAsync(city)).ReturnsAsync(new WeatherData());
            mockService.Setup(s => s.GetHistory(city, null, null)).Returns(new List<WeatherData>
            {
                new WeatherData { City = city, Date = DateTime.Now, Temperatura = 22 }
            }.AsQueryable());

            var controller = new WeatherController(mockService.Object);
            
            var result = await controller.Index(city) as ViewResult;
            
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<List<WeatherData>>(result.Model);
            Assert.Single(model);
            Assert.Equal("Curitiba", model[0].City);
        }
    }
}
