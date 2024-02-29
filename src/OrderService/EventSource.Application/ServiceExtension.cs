using EventSource.Domain.Order;
using EventSource.Persistence;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using EventSource.Application.Orders.Commands.Validators;
using EventSource.Application.Orders.Queries.Validators;
using MediatR;

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