using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    [Table("movie")]
    public class Movie : EntityBase
    {
        #region Constructor
        
        public Movie()
        {
            OriginalTitle = string.Empty;
            Title = string.Empty;

            MovieGenres = new List<MovieGenre>();
            MovieActors = new List<MovieActor>();
            MovieDirectors = new List<MovieDirector>();
            MovieWriters = new List<MovieWriter>();
        }

        #endregion

        #region Properties

        [Column("original_title")]
        public string OriginalTitle { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("plot")]
        public string? Plot { get; set; }

        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Column("runtime")]
        public int Runtime { get; set; }

        [Column("poster")]
        public string? Poster { get; set; }

        [Column("trailers")]
        public string? Trailers { get; set; }

        [Column("movie_file")]
        public string? MovieFile { get; set; }

        [Column("verified")]
        public bool Verified { get; set; }

        public virtual List<MovieGenre> MovieGenres { get; set; }

        public virtual List<MovieActor> MovieActors { get; set; }

        public virtual List<MovieDirector> MovieDirectors { get; set; }

        public virtual List<MovieWriter> MovieWriters { get; set; }

        public virtual List<MovieSaga> MovieSagas { get; set; }

        #endregion
    }
}
