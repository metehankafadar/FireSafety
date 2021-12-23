using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Business.Interface
{
    interface IEquipmentTypeService
    {
        List<EquipmentType> GetAllEquipmentType();
        int InsertEquipmentType(EquipmentType equipmentType);
        EquipmentType GetEquipmentTypeById(int id);
        int UpdateEquipmentType(EquipmentType equipmentType,int id);
        int DeleteEquipmentType(EquipmentType equipmentType);
    }
}
