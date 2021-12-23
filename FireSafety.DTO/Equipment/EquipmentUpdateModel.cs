using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.DTO.Equipment
{
    public class EquipmentUpdateModel
    {
        public int Id { get; set; }
        public int EquipmentNo { get; set; }
        public string SeriNo { get; set; }
        public int EquipmentTypeId { get; set; }
        public int ProductionUnitId { get; set; }

        public string ProductionUnitLocation { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsAcvite { get; set; }

    }
}
