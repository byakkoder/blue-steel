using Byakkoder.BlueSteel.Infrastructure.Data.Entities;

namespace Byakkoder.BlueSteel.Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly MovieDBContext _movieDBContext;
        private readonly GenericRepository<Movie> _moviesRepository;
        private readonly GenericRepository<Person> _personRepository;
        private readonly GenericRepository<Genre> _genreRepository;
        private readonly GenericRepository<Settings> _settingsRepository;
        private readonly GenericRepository<Saga> _sagaRepository;
        private readonly GenericRepository<Device> _devicesRepository;

        private readonly GenericRepository<MovieGenre> _movieGenreRepository;
        private readonly GenericRepository<MovieActor> _movieActorRepository;
        private readonly GenericRepository<MovieDirector> _movieDirectorRepository;
        private readonly GenericRepository<MovieWriter> _movieWriterRepository;
        private readonly GenericRepository<MovieSaga> _movieSagaRepository;

        private bool disposed = false;

        public UnitOfWork()
        {
            _movieDBContext = new MovieDBContext();
            
            _moviesRepository = new GenericRepository<Movie>(_movieDBContext);
            _personRepository = new GenericRepository<Person>(_movieDBContext);
            _genreRepository = new GenericRepository<Genre>(_movieDBContext);
            _settingsRepository = new GenericRepository<Settings>(_movieDBContext);
            _sagaRepository = new GenericRepository<Saga>(_movieDBContext);
            _devicesRepository = new GenericRepository<Device>(_movieDBContext);
            
            _movieGenreRepository = new GenericRepository<MovieGenre>(_movieDBContext);
            _movieActorRepository = new GenericRepository<MovieActor>(_movieDBContext);
            _movieDirectorRepository = new GenericRepository<MovieDirector>(_movieDBContext);
            _movieWriterRepository = new GenericRepository<MovieWriter>(_movieDBContext);
            _movieSagaRepository = new GenericRepository<MovieSaga>(_movieDBContext);
        }

        public GenericRepository<Movie> MoviesRepository()
        {
            return _moviesRepository;
        }

        public GenericRepository<Person> PeopleRepository()
        {
            return _personRepository;
        }

        public GenericRepository<Genre> GenreRepository()
        {
            return _genreRepository;
        }

        public GenericRepository<Settings> SettingsRepository()
        {
            return _settingsRepository;
        }

        public GenericRepository<Saga> SagaRepository()
        {
            return _sagaRepository;
        }

        public GenericRepository<Device> DevicesRepository()
        {
            return _devicesRepository;
        }

        public GenericRepository<MovieGenre> MovieGenreRepository()
        {
            return _movieGenreRepository;
        }

        public GenericRepository<MovieActor> MovieActorRepository()
        {
            return _movieActorRepository;
        }

        public GenericRepository<MovieDirector> MovieDirectorRepository()
        {
            return _movieDirectorRepository;
        }

        public GenericRepository<MovieWriter> MovieWriterRepository()
        {
            return _movieWriterRepository;
        }

        public GenericRepository<MovieSaga> MovieSagaRepository()
        {
            return _movieSagaRepository;
        }

        public void Save()
        {
            _movieDBContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _movieDBContext?.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
