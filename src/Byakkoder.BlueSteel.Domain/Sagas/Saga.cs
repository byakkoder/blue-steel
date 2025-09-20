using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Common;
using Byakkoder.BlueSteel.Domain.Shared;

namespace Byakkoder.BlueSteel.Domain.Sagas
{
    public sealed class Saga : Entity<SagaId>
    {
        public string Name { get; private set; }

        private Saga(SagaId id, string name) : base(id) => Name = name;

        public static Saga Create(SagaId id, string name)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            return new Saga(id, name.Trim());
        }

        public void Rename(string name)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            Name = name.Trim();
        }
    }
}
