using EventSource.Domain.Order;
using Marten;
using System.Linq.Expressions;

namespace EventSource.Persistence
{
    public class OrderQueryableRepository(IQuerySession querySession) : IOrderQueryableRepository
    {
        public IEnumerable<OrderEntity> Get()
        {
            return querySession.Query<OrderEntity>();
        }

        public IEnumerable<OrderEntity> Get(Expression<Func<OrderEntity, bool>> filter, CancellationToken cancel)
        {
            return querySession.Query<OrderEntity>().Where(filter);
        }

        public async Task<OrderEntity?> GetSingleAsync(Guid id, CancellationToken cancel)
        {
            return await querySession.Query<OrderEntity>().Where(x => x.Id == id).FirstOrDefaultAsync(cancel);
        }

    }
}
