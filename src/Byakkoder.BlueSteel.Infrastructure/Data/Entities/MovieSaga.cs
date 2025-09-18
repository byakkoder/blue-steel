using System.ComponentModel.DataAnnotations.Schema;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    [Table("moviesaga")]
    public class MovieSaga : EntityBase
    {
        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("saga_id")]
        public int SagaId { get; set; }

        [Column("movie_order")]
        public int MovieOrder { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Saga Saga { get; set; }
    }
}
