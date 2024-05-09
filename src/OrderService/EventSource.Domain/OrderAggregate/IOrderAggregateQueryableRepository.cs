namespace EventSource.Domain.OrderAggregate;

public interface IOrderAggregateQueryableRepository
{
    Task<OrderAggregateEntity?> GetAggregateLiveSingleAsync(Guid id, CancellationToken cancel);
    Task<OrderAggregateEntity?> GetAggregateAsyncSingleAsync(Guid id, CancellationToken cancel);
}
