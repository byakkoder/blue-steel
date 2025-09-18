using System.ComponentModel.DataAnnotations.Schema;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    [Table("saga")]
    public class Saga : EntityBase
    {
        [Column("saga_name")]
        public string Name { get; set; } = string.Empty;

        public virtual List<MovieSaga> MovieSagas { get; set; }
    }
}
