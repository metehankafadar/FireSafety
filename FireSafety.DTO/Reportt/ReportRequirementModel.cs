using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.DTO.Reportt
{
  public  class ReportRequirementModel
    {
        public string ProductionUnitName { get; set; }
        public string ProductionLocationName { get; set; }
        public string EquipmentTypeName { get; set; }
        public int EquipmentCount { get; set; }
        public int RequirementCount { get; set; }
      

        
    }
}
