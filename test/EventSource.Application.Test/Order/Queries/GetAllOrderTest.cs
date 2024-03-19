using EventSource.Application.Orders.QueryHandlers;
using EventSource.Domain.Order;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace EventSource.Application.Test.Order.Queries;

public class GetAllOrderTest
{
    [Fact]
    public async Task GetAllOrder()
    {
        var loggerFactory = new LoggerFactory();
        var logger = loggerFactory.CreateLogger<GetAllOrdersQueryHandler>();
        var orderRepository = Substitute.For<IOrderQueryableRepository>();

        GetAllOrdersQueryHandler queryHandler = new(orderRepository);

        var result = await queryHandler.Handle(new Orders.Queries.GetAllOrdersCommand(), CancellationToken.None);

        Assert.Empty(result);
    }


    public async Task GetAllOrderWithSearch()
    {
        var loggerFactory = new LoggerFactory();
        var logger = loggerFactory.CreateLogger<GetAllOrdersQueryHandler>();
        var orderRepository = Substitute.For<IOrderQueryableRepository>();

        GetAllOrdersQueryHandler createOrderCommandHandler = new(orderRepository);

        var result = await createOrderCommandHandler.Handle(new Orders.Queries.GetAllOrdersCommand() { SeachOnDescription = "Test" }, CancellationToken.None);

        Assert.Empty(result);
    }

}