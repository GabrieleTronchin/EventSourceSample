using Marten;
using Microsoft.Extensions.DependencyInjection;

namespace EventSource.Persistence;

public static class ServicesExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddMarten(options =>
        {
            const string connectionString = "host=localhost;port=5432;database=orders;username=web;password=webpw;";
            options.Connection(connectionString);
        });

        return services;
    }
}
