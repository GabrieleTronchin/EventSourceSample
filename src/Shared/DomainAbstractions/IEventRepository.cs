namespace Domain.Abstractions;

public interface IEventRepository<in T>
    where T : class
{
    Task StartStream(Guid Id);

    Task Append<T>(Guid Id, T entity);
}
