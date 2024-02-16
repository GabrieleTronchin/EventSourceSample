using System.Linq.Expressions;

namespace EventSource.Application.Orders;

public interface IOrderQueryableRepository
{
    IEnumerable<OrderReadModel> Get();
    IEnumerable<OrderReadModel> Get(Expression<Func<OrderReadModel, bool>> filter, CancellationToken cancel);
    Task<OrderReadModel?> GetSingleAsync(Guid id, CancellationToken cancel);
}