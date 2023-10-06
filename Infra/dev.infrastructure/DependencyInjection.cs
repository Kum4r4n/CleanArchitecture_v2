using dev.Application.Common.Interfaces;
using dev.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dev.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("dev_db"), 
                b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ), ServiceLifetime.Transient);

            services.AddScoped<IApplicationDbContext>(option => option.GetService<ApplicationDbContext>());
            return services;

        }

    }
}