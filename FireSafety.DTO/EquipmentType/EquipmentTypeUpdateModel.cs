using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.DTO.EquipmentType
{
    public class EquipmentTypeUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActived { get; set; }
    }
}
