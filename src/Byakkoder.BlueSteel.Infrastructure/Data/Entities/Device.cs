using System.ComponentModel.DataAnnotations.Schema;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    [Table("devices")]
    public class Device : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("ip")]
        public string Ip { get; set; }
    }
}
