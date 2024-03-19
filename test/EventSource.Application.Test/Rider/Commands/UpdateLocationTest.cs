using Domain.Abstractions;
using EventSource.Application.Rider.CommandHandlers;
using EventSource.Application.Rider.Commands;
using EventSource.Domain.Rider;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace EventSource.Application.Test.Rider.Commands;

public class UpdateLocationTest
{
    [Fact]
    public async Task UpdateLocation()
    {
        var loggerFactory = new LoggerFactory();
        var logger = loggerFactory.CreateLogger<UpdateLocationCommandHandler>();

        var eventRiderRepository = Substitute.For<IEventRepository<RiderEntity>>();

        UpdateLocationCommandHandler commandHandler = new(logger, eventRiderRepository);

        var result = await commandHandler.Handle(new UpdateLocationCommand() { Latitute = 1, Longitude = 1, RirderId = new() }, CancellationToken.None);

        Assert.NotNull(result);
    }
}