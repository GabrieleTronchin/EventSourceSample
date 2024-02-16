using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weasel.Core;

namespace EventSource.Application;

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
