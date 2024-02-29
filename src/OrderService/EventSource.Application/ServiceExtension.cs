using EventSource.Application.Orders.Queries.Validators;
using EventSource.Domain.Order;
using EventSource.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventSource.Application;

public static class ServicesExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServicesExtensions).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(typeof(ServicesExtensions).Assembly);

        services.AddPersistence();
        services.AddTransient<IOrderQueryableRepository, OrderQueryableRepository>();

        return services;

    }
}