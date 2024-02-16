using EventSource.Domain.Order;
using Marten;
using System.Linq.Expressions;

namespace EventSource.Persistence
{
    public class OrderRepository(DocumentStore store) : IOrderRepository
    {

        //TODO Implement in a correct way
        // https://www.youtube.com/watch?v=yWpuUHXLhYg&ab_channel=CodeOpinion

        public async Task AddAsync(OrderEntity entity)
        {
            using var session = store.LightweightSession();
            session.Store(entity);
            await session.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderEntity>> GetAsync(Expression<Func<OrderEntity, bool>> filter, CancellationToken cancel)
        {
            using var session = store.LightweightSession();
            return session.Query<OrderEntity>().Where(filter);
        }

        public async Task<OrderEntity?> GetSingleAsync(Guid id, CancellationToken cancel)
        {
            using var session = store.LightweightSession();
            return await session.Query<OrderEntity>().Where(x => x.Id == id).FirstOrDefaultAsync(cancel);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
