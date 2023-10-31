using Microsoft.Extensions.DependencyInjection;

namespace Ucms.DAL.Impl.Extensions;

public static class DataSeaderExtensions
{
    public static IServiceCollection SeedData(this IServiceCollection services)
    {
        services.AddSingleton<DatabaseSeeder>();
        var serviceProvider = services.BuildServiceProvider();
        var databaseSeeder = serviceProvider.GetRequiredService<DatabaseSeeder>();
        databaseSeeder.SeedDatabase();

        return services;
    }
}
