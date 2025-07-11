using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Data;
using WeatherApp.Services;

namespace WeatherApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("WeatherDb"));
            services.AddScoped<WeatherService>();
            services.AddHostedService<WeatherBackgroundService>();
            services.AddControllersWithViews();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Weather}/{action=Index}/{id?}");
            });
        }
    }
}
