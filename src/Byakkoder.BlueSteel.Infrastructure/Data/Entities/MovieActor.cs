using System.ComponentModel.DataAnnotations.Schema;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    [Table("movieactor")]
    public class MovieActor : EntityBase
    {
        #region Properties

        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("person_id")]
        public int PersonId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Person Person { get; set; } 

        #endregion
    }
}
