using EventSource.Application.Orders.QueryHandlers;
using EventSource.Domain.Order;
using EventSource.Domain.OrderAggregate;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace EventSource.Application.Test.Order.Queries;

public class GetOrderLiveProjectionTest
{
    [Fact]
    public async Task OrderLiveProjectionWIthOrderNotFoundTest()
    {
        var loggerFactory = new LoggerFactory();
        var logger = loggerFactory.CreateLogger<GetOrderLiveProjectionQueryHandler>();
        var orderRepository = Substitute.For<IOrderQueryableRepository>();
        var orderAggregateRepository = Substitute.For<IOrderAggregateQueryableRepository>();


        GetOrderLiveProjectionQueryHandler queryHandler = new(orderAggregateRepository, orderRepository);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
                queryHandler.Handle(
                    new Orders.Queries.GetOrderLiveProjectionCommand() { OrderId = new() },
                    CancellationToken.None));
    }


}