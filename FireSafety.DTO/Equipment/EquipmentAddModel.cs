﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.DTO.Equipment
{
    public class EquipmentAddModel
    {
        
        public string SeriNo { get; set; }
        public int EquipmentTypeId { get; set; }
        public int ProductionUnitId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsAcvite { get; set; }
        public string EquipmentNo { get; set; }


    }
}
