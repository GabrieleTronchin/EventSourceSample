using System.Linq.Expressions;

namespace EventSource.Domain.Order;

public interface IOrderQueryableRepository
{
    IEnumerable<OrderEntity> Get();
    Task<IEnumerable<OrderEntity>> Get(
        Expression<Func<OrderEntity, bool>>? filter,
        CancellationToken cancel
    );
    Task<OrderEntity?> GetSingleAsync(Guid id, CancellationToken cancel);
}
