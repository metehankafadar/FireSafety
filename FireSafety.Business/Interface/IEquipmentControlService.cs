using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Business.Interface
{
    interface IEquipmentControlService
    {
        List<EquipmentControl> GetAllEquipmentControls();
        int InsertEquipmentControl(EquipmentControl equipmentControl);
        EquipmentControl GetEquipmentControlById(int id);
        int UpdateEquipmentControl(EquipmentControl equipmentControl,int id);
        int DeleteEquipmentControl(EquipmentControl equipmentControl);
    }
}
