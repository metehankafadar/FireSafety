using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.DTO.ProductionRequirement
{
    public class ProductionRequirementAddModel
    {
        public int Count { get; set; }

        public int EquipmentId { get; set; }

        public int ProductionUnitId { get; set; }
        public bool IsActive { get; set; }

    }
}
