using System.ComponentModel.DataAnnotations.Schema;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    public class EntityBase
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
