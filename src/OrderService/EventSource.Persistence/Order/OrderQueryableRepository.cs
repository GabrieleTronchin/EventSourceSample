using EventSource.Domain.Order;
using Marten;
using System.Linq.Expressions;

namespace EventSource.Persistence.Order
{
    public class OrderQueryableRepository(IQuerySession querySession) : IOrderQueryableRepository
    {
        public IEnumerable<OrderEntity> Get()
        {
            return querySession.Query<OrderEntity>();
        }

        public async Task<IEnumerable<OrderEntity>> Get(Expression<Func<OrderEntity, bool>>? filter, CancellationToken cancel)
        {
            if (filter == null)
                return await querySession.Query<OrderEntity>().Take(1000).ToListAsync();
            else
                return await querySession.Query<OrderEntity>().Where(filter).ToListAsync();
        }

        public async Task<OrderEntity?> GetSingleAsync(Guid id, CancellationToken cancel)
        {
            return await querySession.Query<OrderEntity>().Where(x => x.Id == id).FirstOrDefaultAsync(cancel);
        }

    }
}
