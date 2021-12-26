using FireSafety.Data.repository;
using FireSafety.DTO.Reportt;
using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Business
{
    public class ReportService
    {
        Repository<EquipmentControl> equipmentControlRepository = new Repository<EquipmentControl>();
        Repository<ProductionRequirement> productionRequirementRepository = new Repository<ProductionRequirement>();
        Repository<Equipment> equipmentRepository = new Repository<Equipment>();

        public List<ControlReportModel> getControl(int productionUnitId)
        {
            List<EquipmentControl> result = new List<EquipmentControl>();
            List<ControlReportModel> listrep = new List<ControlReportModel>();
            if (productionUnitId == 0)
            {
                result = equipmentControlRepository.List();
            }
            else
            {
                result = equipmentControlRepository.List(p => p.Equipment.ProductionUnitId == productionUnitId);
               
            }
            foreach (var item in result)
            {
                ControlReportModel take = new ControlReportModel();
                take.EquipmentSeriNo = item.Equipment.SeriNo;
                take.EquipmentTypeName = item.Equipment.EquipmentType.Name;
                take.PhysicalInspection = item.PhysicalInspection;
                take.PressureLevel = item.PressureLevel;
                take.ProductionLocationName = item.Equipment.ProductionUnit.Location;
                take.ProductionUnitName = item.Equipment.ProductionUnit.Name;
                take.ProtectionPinStatus = item.ProtectionPinStatus;
                take.IsActived = item.IsActive;
                take.ControlDate = item.ControlDate;
                take.CreatedByUser = item.CreatedByUser;
                listrep.Add(take);
            }


            return listrep;
            //TODO: resulttan al teni modelliste ekle return et
        }

        public List<ReportRequirementModel> getRequirement(int productionUnitId)
        {
            List<ProductionRequirement> requirements;
            List<CountEquipment> counts;
            if (productionUnitId == 0)
            {
                counts = equipmentRepository.listQueryable()
                    .GroupBy(p=>new { p.ProductionUnitId, p.EquipmentTypeId })
                    .Select(x=> new CountEquipment { Count = x.Count(), EquipmentTypeId = x.Key.EquipmentTypeId, ProductionUnitId = x.Key.ProductionUnitId }).ToList();
                requirements = productionRequirementRepository.List();
            }
            else
            {
                counts = equipmentRepository.listQueryable().Where(p=> p.ProductionUnitId == productionUnitId)
                   .GroupBy(p => new { p.ProductionUnitId, p.EquipmentTypeId })
                   .Select(x => new CountEquipment { Count = x.Count(), EquipmentTypeId = x.Key.EquipmentTypeId, ProductionUnitId = x.Key.ProductionUnitId }).ToList();
                requirements = productionRequirementRepository.List(p=>p.ProductionUnitId == productionUnitId);
            }
            List<ReportRequirementModel> listModels = new List<ReportRequirementModel>();
            foreach (var item in requirements)
            {
                ReportRequirementModel model = new ReportRequirementModel();
                model.RequirementCount = item.Count;
                var count = counts.SingleOrDefault(p => p.EquipmentTypeId == item.EquipmentTypeId && p.ProductionUnitId == item.ProductionUnitId);
                model.EquipmentCount = (count==null)?0:count.Count;
                model.EquipmentTypeName = item.EquipmentType.Name;
                model.ProductionLocationName = item.ProductionUnit.Location;
                model.ProductionUnitName = item.ProductionUnit.Name;
                listModels.Add(model);
            }
            return listModels;
            
        }
    }
        public class CountEquipment
        {
            public int Count;
            public int EquipmentTypeId;
            public int ProductionUnitId;
        }

}
