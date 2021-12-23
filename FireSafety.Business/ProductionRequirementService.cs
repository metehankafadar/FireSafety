using FireSafety.Business.Interface;
using FireSafety.Data.repository;
using FireSafety.DTO.ProductionRequirement;
using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Business
{
    public class ProductionRequirementService 
    {
        Repository<ProductionRequirement> productionRequirementRepository = new Repository<ProductionRequirement>();
        public int DeleteProductionRequirement(int id)
        {
            var item = productionRequirementRepository.Find(p => p.Id == id);
            return productionRequirementRepository.Delete(item);
        }

        public List<ProductionRequirementListModel> GetAllProductionRequirement()
        {
            List<ProductionRequirementListModel> listModels = new List<ProductionRequirementListModel>();
            List<ProductionRequirement> equipmentsControl = productionRequirementRepository.List();

            foreach (var item in equipmentsControl)
            {

                ProductionRequirementListModel model = new ProductionRequirementListModel();
                model.Count = item.Count;
                model.EquipmentName = item.Equipment.EquipmentType.Name;
                model.ProductionUnitName = item.ProductionUnit.Name;

                listModels.Add(model);

            }


            return listModels;
        }

        public ProductionRequirementListModel GetProductionRequirementById(int id)
        {
            var item = productionRequirementRepository.Find(p => p.Id == id);
            ProductionRequirementListModel model = new ProductionRequirementListModel();
            model.Count = item.Count;
            model.EquipmentName = item.Equipment.EquipmentType.Name;
            model.ProductionUnitName = item.ProductionUnit.Name;
            item.IsActive = model.IsActive;

            return model;
        }

        public int InsertProductionRequiremente(ProductionRequirementAddModel model)
        {
            ProductionRequirement item = new ProductionRequirement();
            item.Count = model.Count;
            item.ProductionUnitId = model.ProductionUnitId;
            item.EquipmentId = model.EquipmentId;
            item.IsActive = model.IsActive;
            return productionRequirementRepository.Insert(item);
        }

        public int UpdateProductionRequirement(ProductionRequirementUpdateModel productionRequirement)
        {
            ProductionRequirement pr = productionRequirementRepository.Find(e => e.Id == productionRequirement.Id);
            pr.EquipmentId = productionRequirement.EquipmentId;
            pr.IsActive = productionRequirement.IsActive;
            pr.ProductionUnitId = productionRequirement.ProductionUnitId;


            return productionRequirementRepository.Update(pr);
        }
        public List<ProductionRequirementListModel> GetAllByProductionUniteId(int id)
        {
            List<ProductionRequirementListModel> listModels = new List<ProductionRequirementListModel>();
            List<ProductionRequirement> equipmentsControl = productionRequirementRepository.List(p=> p.ProductionUnitId == id);

            foreach (var item in equipmentsControl)
            {

                ProductionRequirementListModel model = new ProductionRequirementListModel();
                model.Count = item.Count;
                model.EquipmentName = item.Equipment.EquipmentType.Name;
                model.ProductionUnitName = item.ProductionUnit.Name;

                listModels.Add(model);

            }


            return listModels;
        }

    }
}
