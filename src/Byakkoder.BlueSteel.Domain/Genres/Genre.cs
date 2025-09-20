using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Common;
using Byakkoder.BlueSteel.Domain.Shared;

namespace Byakkoder.BlueSteel.Domain.Genres
{
    public sealed class Genre : Entity<GenreId>
    {
        public string Name { get; private set; }

        private Genre(GenreId id, string name) : base(id) => Name = name;

        public static Genre Create(GenreId id, string name)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            return new Genre(id, name.Trim());
        }

        public void Rename(string newName)
        {
            Guard.AgainstNullOrWhiteSpace(newName, nameof(newName));
            Name = newName.Trim();
        }
    }
}
