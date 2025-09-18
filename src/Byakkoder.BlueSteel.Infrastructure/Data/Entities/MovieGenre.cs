using System.ComponentModel.DataAnnotations.Schema;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    [Table("moviegenre")]
    public class MovieGenre : EntityBase
    {
        #region Properties

        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("genre_id")]
        public int GenreId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Genre Genre { get; set; } 

        #endregion
    }
}
