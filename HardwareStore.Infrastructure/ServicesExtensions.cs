using HardwareHub.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApplicationServices.Interfaces.Repositories;
using HardwareHub.Infrastructure.Repositories;

namespace HardwareHub.Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services , IConfiguration conf)
        {
            /*?? throw new InvalidOperationException("The DataBase 'HardwareHub' not found")));*/


            services.AddDbContext<HardwareHubContext>(options => options.UseSqlServer(conf.GetConnectionString("HardwareHubDB") ?? throw new InvalidOperationException("Connectionstring 'HardwareHub' not found.")));


            //services.AddTransient<IBrandsRepositorie, BrandRepositorie>();
            services.AddTransient(typeof(IRepositorie<>), typeof(RepositorieArdalis<>));
        }
    }
}
