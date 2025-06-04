using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Services;
using System;
using System.Linq;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index(string city = "Curitiba", DateTime? start = null, DateTime? end = null)
        {
            await _weatherService.GetWeatherAsync(city);
            var data = _weatherService.GetHistory(city, start, end).OrderByDescending(w => w.Date).ToList();
            ViewBag.City = city;
            return View(data);
        }
    }
}
