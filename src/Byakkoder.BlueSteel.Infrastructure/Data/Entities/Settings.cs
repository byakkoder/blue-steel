using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    [Table("settings")]
    public class Settings : EntityBase
    {
        [Column("key")]
        public string Key { get; set; } = "";

        [Column("value")]
        public string? Value { get; set; }
    }
}
