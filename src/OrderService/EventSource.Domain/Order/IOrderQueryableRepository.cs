using System.Linq.Expressions;

namespace EventSource.Domain.Order;

public interface IOrderQueryableRepository
{
    IEnumerable<OrderEntity> Get();
    Task<IEnumerable<OrderEntity>> Get(Expression<Func<OrderEntity, bool>>? filter, CancellationToken cancel);
    Task<OrderEntity?> GetSingleAsync(Guid id, CancellationToken cancel);
    Task<OrderEntity?> GetAggregateLiveSingleAsync(Guid id, CancellationToken cancel);
    Task<OrderEntity?> GetAggregateAsyncSingleAsync(Guid id, CancellationToken cancel);
}