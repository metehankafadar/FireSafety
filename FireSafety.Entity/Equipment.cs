using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FireSafety.Entity
{
    [Table("Equipments")]
    public class Equipment:BaseEntity
    {
        
        public string SeriNo { get; set; }
        public string EquipmentNo { get; set; }
        public int EquipmentTypeId { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }
        public int ProductionUnitId { get; set; }
        public virtual ProductionUnit ProductionUnit { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "6/6/2079")]
        public DateTime ExpirationDate { get; set; }
    }
}





