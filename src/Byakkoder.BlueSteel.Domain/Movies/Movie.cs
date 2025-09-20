using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Common;
using Byakkoder.BlueSteel.Domain.Files;
using Byakkoder.BlueSteel.Domain.Shared;

namespace Byakkoder.BlueSteel.Domain.Movies
{
    public sealed class Movie : AggregateRoot<MovieId>
    {
        private readonly HashSet<GenreId> _genres = new();
        private readonly HashSet<PersonId> _directors = new();
        private readonly HashSet<PersonId> _writers = new();
        private readonly HashSet<SagaId> _sagas = new();
        private readonly List<MovieCast> _cast = new();
        private readonly List<Trailer> _trailers = new();

        public string OriginalTitle { get; private set; }
        public string Title { get; private set; }
        public string? Plot { get; private set; }
        public DateOnly? ReleaseDate { get; private set; }
        public TimeSpan Runtime { get; private set; } // minutes precision
        public FileName PosterFileName { get; private set; }
        public FileName MovieFileName { get; private set; }

        public IReadOnlyCollection<GenreId> Genres => _genres;
        public IReadOnlyCollection<PersonId> Directors => _directors;
        public IReadOnlyCollection<PersonId> Writers => _writers;
        public IReadOnlyCollection<SagaId> Sagas => _sagas;
        public IReadOnlyList<MovieCast> Cast => _cast;
        public IReadOnlyList<Trailer> Trailers => _trailers;

        private Movie(MovieId id,
                      string originalTitle,
                      string title,
                      string? plot,
                      DateOnly? releaseDate,
                      TimeSpan runtime,
                      FileName posterFileName,
                      FileName movieFileName) : base(id)
        {
            OriginalTitle = originalTitle;
            Title = title;
            Plot = plot;
            ReleaseDate = releaseDate;
            Runtime = runtime;
            PosterFileName = posterFileName;
            MovieFileName = movieFileName;
        }

        public static Movie Create(MovieId id,
                                   string originalTitle,
                                   string title,
                                   string? plot,
                                   DateOnly? releaseDate,
                                   int runtimeMinutes,
                                   FileName posterFileName,
                                   FileName movieFileName)
        {
            Guard.AgainstNullOrWhiteSpace(originalTitle, nameof(originalTitle));
            Guard.AgainstNullOrWhiteSpace(title, nameof(title));
            if (runtimeMinutes <= 0) throw new ArgumentOutOfRangeException(nameof(runtimeMinutes), "Runtime must be > 0 minutes.");

            var movie = new Movie(id, originalTitle.Trim(), title.Trim(), plot?.Trim(), releaseDate,
                                  TimeSpan.FromMinutes(runtimeMinutes), posterFileName, movieFileName);

            movie.Raise(new MovieRegisteredDomainEvent(movie.Id));
            return movie;
        }

        // Domain behavior
        public void Rename(string newTitle)
        {
            Guard.AgainstNullOrWhiteSpace(newTitle, nameof(newTitle));
            Title = newTitle.Trim();
        }

        public void SetPlot(string? plot) => Plot = string.IsNullOrWhiteSpace(plot) ? null : plot.Trim();

        public void AddGenre(GenreId genreId) => _genres.Add(genreId);
        public void RemoveGenre(GenreId genreId) => _genres.Remove(genreId);

        public void AddDirector(PersonId personId) => _directors.Add(personId);
        public void AddWriter(PersonId personId) => _writers.Add(personId);
        public void RemoveDirector(PersonId personId) => _directors.Remove(personId);
        public void RemoveWriter(PersonId personId) => _writers.Remove(personId);

        public void AddToSaga(SagaId sagaId) => _sagas.Add(sagaId);
        public void RemoveFromSaga(SagaId sagaId) => _sagas.Remove(sagaId);

        public void AddCast(PersonId personId, int order, string? characterName = null)
            => _cast.Add(MovieCast.Create(personId, order, characterName));

        public void ClearCast() => _cast.Clear();

        public void AddTrailer(string title, string url) => _trailers.Add(Trailer.Create(title, url));
        public void RemoveTrailer(Trailer trailer) => _trailers.Remove(trailer);

        // Safety helper for file names (enforces invariants)
        public void ChangePosterFileName(FileName newPoster) => PosterFileName = newPoster;
        public void ChangeMovieFileName(FileName newFile) => MovieFileName = newFile;
    }
}
