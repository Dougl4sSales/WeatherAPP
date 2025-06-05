using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Data;
using System;
using System.Linq;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
        private const string ApiKey = "3d4ffe104a707ac477972faeb811a6df"; 

        public WeatherService(AppDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            var response = await _httpClient.GetStringAsync(
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric&lang=pt_br");

            using JsonDocument doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            var data = new WeatherData
            {
                City = city,
                Date = DateTime.Now,
                Temperatura = root.GetProperty("main").GetProperty("temp").GetDouble(),
                SensacaoTermica = root.GetProperty("main").GetProperty("feels_like").GetDouble(),
                TemperatureMin = root.GetProperty("main").GetProperty("temp_min").GetDouble(),
                TemperatureMax = root.GetProperty("main").GetProperty("temp_max").GetDouble(),
                Description = root.GetProperty("weather")[0].GetProperty("description").GetString() ?? "Sem descrição",   
                Icon = root.GetProperty("weather")[0].GetProperty("icon").GetString() ?? "01d"             
            };

            _context.Weather.Add(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public IQueryable<WeatherData> GetHistory(string city, DateTime? start, DateTime? end)
        {
            var query = _context.Weather.Where(w => w.City == city);

            if (start.HasValue)
                query = query.Where(w => w.Date >= start.Value);

            if (end.HasValue)
                query = query.Where(w => w.Date <= end.Value);

            return query;
        }
    }
}
