using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FireSafety.Entity
{
    [Table("EquipmentControls")]
    public class EquipmentControl : BaseEntity
    {
        public bool PhysicalInspection { get; set; }
        public Double PressureLevel { get; set; }
        public bool ProtectionPinStatus { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "6/6/2079")]
        public DateTime ControlDate { get; set; }
        public string CreatedByUser { get; set; }

        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
    }                       
}

