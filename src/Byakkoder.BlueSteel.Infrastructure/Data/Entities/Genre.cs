using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    [Table("genre")]
    public class Genre : EntityBase
    {
        public Genre()
        {
            MovieGenres = new List<MovieGenre>();
        }

        #region Properties

        [Column("genre_name")]
        public string Name { get; set; }

        public virtual List<MovieGenre> MovieGenres { get; set; }

        #endregion
    }
}
