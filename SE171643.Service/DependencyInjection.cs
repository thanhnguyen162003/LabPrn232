using Microsoft.Extensions.DependencyInjection;
using SE171643.Service.Abstractions;
using SE171643.Service.Security;

namespace SE171643.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddSingleton<JwtHelper>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
