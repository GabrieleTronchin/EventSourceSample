namespace Domain.Abstractions;

public interface IRepository<in T>
    where T : class
{
    Task SaveChangesAsync();

    Task AddAsync(T entity);
}
