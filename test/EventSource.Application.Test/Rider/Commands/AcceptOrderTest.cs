using Domain.Abstractions;
using EventSource.Application.Rider.CommandHandlers;
using EventSource.Application.Rider.Commands;
using EventSource.Domain.Rider;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace EventSource.Application.Test.Rider.Commands;

public class AcceptOrderTest
{
    [Fact]
    public async Task AcceptOrder()
    {
        var loggerFactory = new LoggerFactory();
        var logger = loggerFactory.CreateLogger<AcceptOrderCommandHandler>();
        var riderRepository = Substitute.For<IRepository<RiderEntity>>();

        var eventRiderRepository = Substitute.For<IEventRepository<RiderEntity>>();

        AcceptOrderCommandHandler commandHandler = new(logger, riderRepository, eventRiderRepository);

        var result = await commandHandler.Handle(new AcceptOrderCommand() { Id = new(), RiderId = new() }, CancellationToken.None);


        Assert.NotNull(result);
        Assert.Equal(result.Id, Guid.Empty);
    }
}