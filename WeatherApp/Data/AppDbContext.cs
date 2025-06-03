using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;

namespace WeatherApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<WeatherData>? Weather { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
