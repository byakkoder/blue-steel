using Byakkoder.BlueSteel.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Byakkoder.BlueSteel.Infrastructure.Data
{
    public class MovieDBContext : DbContext
    {
        private static MovieDBContext _movieDBContext;

        #region DbSets

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Settings> Settings { get; set; }

        public DbSet<Saga> Sagas { get; set; }

        public DbSet<Device> Devices { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Refactor for use in Clean Architecture.
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //string? dbConnectionString = builder.Build().GetSection("ConnectionStrings").GetSection("MoviesConnectionString").Value;

            //if (string.IsNullOrEmpty(dbConnectionString))
            //{
            //    throw new ArgumentException("String connection not found.");
            //}

            //optionsBuilder.UseMySQL(dbConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
