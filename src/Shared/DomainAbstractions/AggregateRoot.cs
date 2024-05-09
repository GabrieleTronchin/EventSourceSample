namespace Domain.Abstractions
{
    public abstract class AggregateRoot
    {
        private readonly IList<IDomainEvent> _events;

        protected AggregateRoot()
        {
            _events = new List<IDomainEvent>();
        }

        public void RaiseEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public IEnumerable<IDomainEvent> GetEvents()
        {
            return _events.ToList();
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}
