using Application.Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;

namespace Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {

            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CurrencyRateDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ICurrencyRateDbContext>(provider =>
                provider.GetService<CurrencyRateDbContext>());

            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IRateRepository, RateRepository>();

            return services;
        }
    }
}
