namespace Byakkoder.BlueSteel.Domain.Abstractions
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; } = default!;
        protected Entity() { }
        protected Entity(TId id) => Id = id;
    }
}
