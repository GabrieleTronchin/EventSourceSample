using EventSource.Domain.Order;
using EventSource.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace EventSource.Application;

public static class ServicesExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServicesExtensions).Assembly));

        //services.AddMassTransit(x =>
        //{
        //    x.SetMartenSagaRepositoryProvider();

        //    var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();

        //    x.AddSagaStateMachines(entryAssembly);

        //    x.AddSagaRepository<OrderState>()
        //        .MartenRepository();
        //});

        services.AddPersistence();
        services.AddTransient<IOrderQueryableRepository, OrderQueryableRepository>();

        return services;

    }
}