
using EventSource.Domain.Primitives;
using System.Linq.Expressions;

namespace EventSource.Domain.Order;

public interface IOrderRepository : IRepository<OrderEntity>
{
    Task<OrderEntity?> GetSingleAsync(Guid id, CancellationToken cancel);
    Task<IEnumerable<OrderEntity>> GetAsync(Expression<Func<OrderEntity, bool>> filter, CancellationToken cancel);
}