using FireSafety.DTO;
using FireSafety.DTO.Equipment;
using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Business.Interface
{
    public interface IEquipmentService
    {
        List<EquipmentListModel> getAllEquipments();
        int InsertEquipment(Equipment equipment);
        EquipmentListModel GetEquipmentById(int id);
        int UpdateEquipment(Equipment equipment,int id);
        int DeleteEquipment(Equipment equipment);
    }
}
