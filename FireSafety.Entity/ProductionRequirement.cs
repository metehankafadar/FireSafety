using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Entity
{
    [Table("ProductionRequirements")]
    public class ProductionRequirement:BaseEntity
    {
        public int Count { get; set; }

        public int EquipmentTypeId { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }

        public int ProductionUnitId { get; set; }

        public virtual ProductionUnit ProductionUnit { get; set; }
    }
}
