using EventSource.Domain.Order;
using Marten;
using System.Linq.Expressions;

namespace EventSource.Persistence
{
    public class OrderRepository(IQuerySession querySession, IDocumentStore store) : IOrderRepository
    {

        //TODO Implement in a correct way
        // https://www.youtube.com/watch?v=yWpuUHXLhYg&ab_channel=CodeOpinion

        public async Task AddAsync(OrderEntity entity)
        {
            using var session = await store.LightweightSerializableSessionAsync();
            session.Store(entity);
            await session.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderEntity>> GetAsync(Expression<Func<OrderEntity, bool>> filter, CancellationToken cancel)
        {
            return querySession.Query<OrderEntity>().Where(filter);
        }

        public async Task<OrderEntity?> GetSingleAsync(Guid id, CancellationToken cancel)
        {
            return await querySession.Query<OrderEntity>().Where(x => x.Id == id).FirstOrDefaultAsync(cancel);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
