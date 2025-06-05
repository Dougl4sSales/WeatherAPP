using System;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public DateTime Date { get; set; }
        public double Temperatura { get; set; }
        public double SensacaoTermica { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public string? Description { get; set; }
        public string Icon { get; set; } = "01d";
    }
}
