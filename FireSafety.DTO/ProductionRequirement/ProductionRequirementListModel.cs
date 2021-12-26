using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.DTO.ProductionRequirement
{
    public class ProductionRequirementListModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string EquipmentTypeName { get; set; }
        

        public string ProductionUnitName { get; set; }
        public bool IsActive { get; set; }



    }
}
