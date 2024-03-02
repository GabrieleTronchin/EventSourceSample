using Domain.Abstractions;
using EventSource.Domain.Order;
using EventSource.Domain.Rider;
using EventSource.Persistence.Order;
using EventSource.Persistence.Rider;
using Marten;
using Microsoft.Extensions.DependencyInjection;

namespace EventSource.Persistence;

public static class ServicesExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddMarten(options =>
        {
            //TODO Move connection string on Appsettings
            const string connectionString = "host=localhost;port=5432;database=orders;username=sa;password=MySecretPassword1234;";
            options.Connection(connectionString);
        });

        services.AddTransient<IRepository<OrderEntity>, OrderRepository>();
        services.AddTransient<IRepository<RiderEntity>, RiderRepository>();


        return services;
    }
}
