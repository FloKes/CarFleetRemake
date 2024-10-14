
using CarFleet.Data;
using CarFleet.Services;
using Microsoft.EntityFrameworkCore;

namespace CarFleet.Installers
{
    public class DbInstaller : IInstaller
    {

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICarService, CarService>();
        }
    }
}
