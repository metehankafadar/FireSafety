using FireSafety.Business.Interface;
using FireSafety.Data;
using FireSafety.Data.repository;
using FireSafety.DTO;
using FireSafety.DTO.EquipmentType;
using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Business
{
    public class EquipmentTypeService 
    {
        Repository<EquipmentType> equipmentTypeRepository = new Repository<EquipmentType>(); 
        public int DeleteEquipmentType(int id)
        {
            var temp = equipmentTypeRepository.Find(e => e.Id == id);
            return equipmentTypeRepository.Delete(temp);
        }

        public List<EquipmentTypeListModel> GetAllEquipmentType()
        {
            List<EquipmentTypeListModel> listModels = new List<EquipmentTypeListModel>();
            List<EquipmentType> equipmentsControl = equipmentTypeRepository.List();

            foreach (var item in equipmentsControl)
            {
                EquipmentTypeListModel model = new EquipmentTypeListModel();
                model.Id = item.Id;
                model.IsActived = item.IsActive;
                model.Name = item.Name;
                listModels.Add(model);

            }


            return listModels;
        }

        public EquipmentTypeListModel GetEquipmentTypeById(int id)
        {
            var temp = equipmentTypeRepository.Find(e => e.Id == id);
            EquipmentTypeListModel model = new EquipmentTypeListModel();
            model.Id = temp.Id;
            model.Name = temp.Name;
            model.IsActived = temp.IsActive;
            return model;
        }

        public int InsertEquipmentType(EquipmentTypeAddModel model)
        {
            EquipmentType nw = new EquipmentType();
            nw.Name = model.Name;
            nw.IsActive = model.IsActived;
            return equipmentTypeRepository.Insert(nw);
        }

        public int UpdateEquipmentType(EquipmentTypeUpdateModel equipmentType )
        {
            EquipmentType eq = equipmentTypeRepository.Find(e => e.Id == equipmentType.Id);
            eq.Id = equipmentType.Id;
            eq.IsActive = equipmentType.IsActived;
            eq.Name = equipmentType.Name;

            return equipmentTypeRepository.Update(eq);
        }
    }
}
