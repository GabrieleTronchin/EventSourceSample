using EventSource.Domain.Order;
using EventSource.Domain.Primitives;
using Marten;


namespace EventSource.Persistence
{
    public class OrderRepository(IDocumentStore store) : IRepository<OrderEntity>
    {

        //TODO Implement in a correct way
        // https://www.youtube.com/watch?v=yWpuUHXLhYg&ab_channel=CodeOpinion

        public async Task AddAsync(OrderEntity entity)
        {
            using var session = await store.LightweightSerializableSessionAsync();
            session.Store(entity);
            await session.SaveChangesAsync();
        }


        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
