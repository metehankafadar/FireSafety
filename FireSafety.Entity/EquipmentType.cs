using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireSafety.Entity
{
    [Table("EquipmentTypes")]
    public class EquipmentType:BaseEntity
    {
        public string Name { get; set; }
    }
}
