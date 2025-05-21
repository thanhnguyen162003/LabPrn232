using Carter;
using Microsoft.EntityFrameworkCore;
using Prn232.Lab2.Data;

namespace Prn232.Lab2;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddDbContext<Lab2DbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}
