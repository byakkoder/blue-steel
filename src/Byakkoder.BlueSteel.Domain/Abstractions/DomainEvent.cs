namespace Byakkoder.BlueSteel.Domain.Abstractions
{
    public interface IDomainEvent { DateTime OccurredOn { get; } }

    public interface IHasDomainEvents
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
    }

    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
