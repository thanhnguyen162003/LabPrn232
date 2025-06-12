
using Lab3.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lab3.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Lab3DbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
        //or can use
        //public static void AddInfrastructure(this WebApplicationBuilder builder)
        //{   var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
        //    builder.Services.AddInfrastructure(connectionString, builder.Configuration);    
        //}
    }
}
