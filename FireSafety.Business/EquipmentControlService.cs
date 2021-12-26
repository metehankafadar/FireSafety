using FireSafety.Business.Interface;
using FireSafety.Data;
using FireSafety.Data.repository;
using FireSafety.DTO;
using FireSafety.DTO.EquipmentControl;
using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Business
{
    public class EquipmentControlService 
    {
        Repository<EquipmentControl> equipmentControlRepository = new Repository<EquipmentControl>();
        Repository<Equipment> equipmentRepository = new Repository<Equipment>();

        public int DeleteEquipmentControl(int id)
        {
            var equipmentControl = equipmentControlRepository.Find(s => s.Id == id);
            return equipmentControlRepository.Delete(equipmentControl);
        }

        public List<EquipmentControlListModel> GetAllEquipmentControls()
        {
            List<EquipmentControlListModel> listModels = new List<EquipmentControlListModel>();
            List<EquipmentControl> equipmentsControl = equipmentControlRepository.List();

            foreach (var item in equipmentsControl)
            {
                EquipmentControlListModel model = new EquipmentControlListModel();
                model.Id = item.Id;
                model.EquipmentSeriNo = item.Equipment.SeriNo;
                model.PressureLevel = item.PressureLevel;
                model.PhysicalInspection = item.PhysicalInspection;
                model.ProtectionPinStatus = item.ProtectionPinStatus;
                model.EquipmentType = item.Equipment.EquipmentType.Name;
                model.ControlDate = item.ControlDate;
                model.CreatedByUser = item.CreatedByUser;
                model.IsActived = item.IsActive;
                model.EquipmentId= item.EquipmentId;
                listModels.Add(model);

            }


            return listModels;
        }

        public EquipmentControlListModel GetEquipmentControlById(int id)
        {
            var item = equipmentControlRepository.Find(s => s.Id == id);
            EquipmentControlListModel model = new EquipmentControlListModel();
            model.PressureLevel = item.PressureLevel;
            model.PhysicalInspection = item.PhysicalInspection;
            model.ProtectionPinStatus = item.ProtectionPinStatus;
            model.EquipmentType = item.Equipment.EquipmentType.Name;
            model.CreatedByUser = item.CreatedByUser;
            model.ControlDate = item.ControlDate;
            model.EquipmentId = item.EquipmentId;


            return model;

             
        }

        public int InsertEquipmentControl(EquipmentControlAddModel model)
        {

            EquipmentControl equipmentControl = new EquipmentControl();
            equipmentControl.PressureLevel = model.PressureLevel;
            equipmentControl.PhysicalInspection = model.PhysicalInspection;
            equipmentControl.ProtectionPinStatus = model.ProtectionPinStatus;
            equipmentControl.EquipmentId = model.EquipmentId;
            equipmentControl.CreatedByUser = model.CreatedByUser;
            equipmentControl.ControlDate = DateTime.Now;

            return equipmentControlRepository.Insert(equipmentControl);
        }

        public int UpdateEquipmentControl(EquipmentControlUpdateModel equipmentControl)
        {
            EquipmentControl eq = equipmentControlRepository.Find(e => e.Id == equipmentControl.Id);
            eq.PhysicalInspection = equipmentControl.PhysicalInspection;
            eq.IsActive = equipmentControl.IsActived;
            eq.PressureLevel = equipmentControl.PressureLevel;
            eq.ProtectionPinStatus = equipmentControl.ProtectionPinStatus;
            eq.ControlDate = DateTime.Now;
            eq.CreatedByUser = equipmentControl.CreatedByUser;
            
            return equipmentControlRepository.Update(eq);
        }

        public EquipmentControlListModel GetEquipmentControlByBarcode(string bar)
        {
            var item = equipmentControlRepository.Find(e => e.Equipment.SeriNo == bar );
            EquipmentControlListModel model = new EquipmentControlListModel();
            model.PressureLevel = item.PressureLevel;
            model.PhysicalInspection = item.PhysicalInspection;
            model.ProtectionPinStatus = item.ProtectionPinStatus;
            model.EquipmentType = item.Equipment.EquipmentType.Name;
            model.EquipmentId = item.EquipmentId;

            return model;
        }

        public List<EquipmentControlListModel> GetEquipmentControlByProductionUniteId(int id)
        {
            var equipments = equipmentRepository.List(p => p.ProductionUnitId == id).Select(p=>p.Id);
            var controls = equipmentControlRepository.List(p=> equipments.Contains(p.EquipmentId));
            List<EquipmentControlListModel> model = new List<EquipmentControlListModel>();
            foreach (var item in controls)
            {
                EquipmentControlListModel md = new EquipmentControlListModel();

                md.PressureLevel = item.PressureLevel;
                md.PhysicalInspection = item.PhysicalInspection;
                md.ProtectionPinStatus = item.ProtectionPinStatus;
                md.EquipmentType = item.Equipment.EquipmentType.Name;
                md.EquipmentId = item.EquipmentId;

                model.Add(md);
            }
            return model;
        }
    }
}
