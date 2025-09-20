using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Shared;

namespace Byakkoder.BlueSteel.Domain.Movies
{
    public sealed class MovieCast : ValueObject
    {
        public PersonId PersonId { get; }
        public string? CharacterName { get; }
        public int Order { get; }

        private MovieCast(PersonId personId, string? characterName, int order)
        {
            PersonId = personId;
            CharacterName = string.IsNullOrWhiteSpace(characterName) ? null : characterName.Trim();
            Order = order;
        }

        public static MovieCast Create(PersonId personId, int order, string? characterName = null)
        {
            if (order < 0) throw new ArgumentOutOfRangeException(nameof(order), "Order must be >= 0.");
            return new MovieCast(personId, characterName, order);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return PersonId;
            yield return CharacterName?.ToLowerInvariant();
            yield return Order;
        }
    }
}
