using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FireSafety.Entity
{
    [Table("Equipments")]
    public class Equipment:BaseEntity
    {
        public int EquipmentNo { get; set; }
        public string SeriNo { get; set; }
        public int EquipmentTypeId { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }
        public int ProductionUnitId { get; set; }
        public virtual ProductionUnit ProductionUnit { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}





