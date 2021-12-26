using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSafety.Business.Interface;
using FireSafety.Data;
using FireSafety.Data.repository;
using FireSafety.DTO;
using FireSafety.DTO.Equipment;
using FireSafety.Entity;

namespace FireSafety.Business
{
    public class EquipmentService 
    {
        EquipmentRepository equipmentRepository = new EquipmentRepository();
        


        public List<EquipmentListModel> getAllEquipments()
        {
            List<EquipmentListModel> listModels = new List<EquipmentListModel>();
            List<Equipment> equipments = equipmentRepository.List();
            
            foreach (var item in equipments)
            {
                EquipmentListModel model = new EquipmentListModel();
                model.Id = item.Id;
                model.EquipmentNo = item.EquipmentNo;
                model.SeriNo = item.SeriNo;
                model.EquipmentTypeName = item.EquipmentType.Name;
                model.ExpirationDate = item.ExpirationDate;
                model.ProductionUnitName = item.ProductionUnit.Name;
                model.ProductionUnitLocation = item.ProductionUnit.Location;
                model.IsAcvite = item.IsActive;
                model.ProductionUnitId = item.ProductionUnit.Id;
                model.EquipmentTypeId = item.EquipmentType.Id;
                listModels.Add(model);

            }

            
            return listModels;
        }
       
        
        
        public int InsertEquipment(EquipmentAddModel model)
        {

            Equipment eq = new Equipment();
            eq.EquipmentNo = model.EquipmentNo;
            eq.SeriNo = model.SeriNo;
            eq.ExpirationDate = model.ExpirationDate;
            eq.EquipmentTypeId = model.EquipmentTypeId;
            eq.ProductionUnitId = model.ProductionUnitId;
            eq.IsActive = model.IsAcvite;
            return equipmentRepository.Insert(eq);
       
        }

        public EquipmentListModel GetEquipmentById(int id)
        {
            var item = equipmentRepository.Find(s => s.Id == id);
            EquipmentListModel model = new EquipmentListModel();
            model.EquipmentNo = item.EquipmentNo;
            model.SeriNo = item.SeriNo;
            model.ExpirationDate = item.ExpirationDate;
            model.EquipmentTypeName = item.EquipmentType.Name;
            model.ProductionUnitLocation = item.ProductionUnit.Location;
            model.IsAcvite = item.IsActive;
            model.ProductionUnitId = item.ProductionUnit.Id;
            model.EquipmentTypeId = item.EquipmentType.Id;

            return model;
        }

       public int UpdateEquipment(EquipmentUpdateModel eq)
        {
            Equipment equipment = equipmentRepository.Find(s =>
            s.Id == eq.Id);
            equipment.EquipmentNo = eq.EquipmentNo;
            equipment.SeriNo = eq.SeriNo;
            equipment.IsActive = eq.IsAcvite;
            equipment.ProductionUnitId = eq.ProductionUnitId;
            equipment.EquipmentTypeId = eq.EquipmentTypeId;
            equipment.ExpirationDate = eq.ExpirationDate;
            

            return equipmentRepository.Update(equipment);
        }

        public int DeleteEquipment(int id)
        {
            Equipment equipment = equipmentRepository.Find(s =>
            s.Id == id);
            return equipmentRepository.Delete(equipment);
        }

        
    }
}