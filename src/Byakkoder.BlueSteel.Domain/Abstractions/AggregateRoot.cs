namespace Byakkoder.BlueSteel.Domain.Abstractions
{
    public abstract class AggregateRoot<TId> : Entity<TId>, IHasDomainEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        protected AggregateRoot() { }
        protected AggregateRoot(TId id) : base(id) { }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        protected void Raise(IDomainEvent @event) => _domainEvents.Add(@event);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
