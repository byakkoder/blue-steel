using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Shared;

namespace Byakkoder.BlueSteel.Domain.Movies
{
    public sealed class MovieRegisteredDomainEvent : DomainEvent
    {
        public MovieId MovieId { get; }
        public MovieRegisteredDomainEvent(MovieId movieId) => MovieId = movieId;
    }
}
