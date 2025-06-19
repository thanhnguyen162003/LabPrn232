using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SE171643.Repository.Abstractions;
using SE171643.Repository.Entities;
using SE171643.Repository.Repositories;

namespace SE171643.Repository
{
    public static class DependencyInjection
    {
     
        public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Summer2025HandbagDbContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();
            services.AddScoped<IHandbagRepository, HandbagRepository>();
            return services;
        }
    }
}
