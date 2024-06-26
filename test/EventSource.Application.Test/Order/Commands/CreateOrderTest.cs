using Domain.Abstractions;
using EventSource.Application.Orders.CommandHandlers;
using EventSource.Domain.Order;
using EventSource.Domain.Rider;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace EventSource.Application.Test.Order.Commands;

public class CreateOrderTest
{
    [Fact]
    public async Task CreateOrder()
    {
        var loggerFactory = new LoggerFactory();
        var logger = loggerFactory.CreateLogger<CreateOrderCommandHandler>();
        var orderRepository = Substitute.For<IRepository<OrderEntity>>();

        var eventRiderRepository = Substitute.For<IEventRepository<RiderEntity>>();

        CreateOrderCommandHandler commandHandler =
            new(logger, orderRepository, eventRiderRepository);

        var result = await commandHandler.Handle(
            new Orders.Commands.CreateOrderCommand() { Description = "Test" },
            CancellationToken.None
        );

        Assert.NotEqual(result.Id, Guid.Empty);
    }
}
