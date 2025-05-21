using Lab2.Repo.Repositories;
using Lab2.Repo.Repositories.Intefaces;
using Microsoft.Extensions.DependencyInjection;

namespace Lab2.Repo;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
