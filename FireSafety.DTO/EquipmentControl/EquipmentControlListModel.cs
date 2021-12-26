using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.DTO
{
    public class EquipmentControlListModel
    {
        public int Id { get; set; }
        public bool PhysicalInspection { get; set; }
        public bool IsActived { get; set; }
        public double PressureLevel { get; set; }
        public bool ProtectionPinStatus { get; set; }
        public DateTime ControlDate { get; set; }
        public string CreatedByUser { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentSeriNo { get; set; }
    }
}
