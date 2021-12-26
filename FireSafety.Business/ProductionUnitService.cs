using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSafety.Business.Interface;
using FireSafety.Data;
using FireSafety.Data.repository;
using FireSafety.DTO.ProductionUnit;
using FireSafety.Entity;

namespace FireSafety.Business
{
    public class ProductionUnitService 
    {
        Repository<ProductionUnit> productionUnitRepository = new Repository<ProductionUnit>();
        public int DeleteProductionUnit(int id)
        {
            var item = productionUnitRepository.Find(p => p.Id == id);
            return productionUnitRepository.Delete(item);
        }

        public List<ProductionUnitListModel> GetAllProductionUnits()
        {
            List<ProductionUnitListModel> listModels = new List<ProductionUnitListModel>();
            List<ProductionUnit> productionUnits = productionUnitRepository.List();

            foreach (var item in productionUnits)
            {
                ProductionUnitListModel model = new ProductionUnitListModel();
                model.Id = item.Id;
                model.Location = item.Location;
                model.Name = item.Name;
                model.IsActive = item.IsActive;
                listModels.Add(model);

            }


            return listModels;
        }

        public ProductionUnitListModel GetProductionUnitById(int id)
        {
            var item = productionUnitRepository.Find(p => p.Id == id);
            ProductionUnitListModel model = new ProductionUnitListModel();
            model.Id = item.Id;
            model.Location = item.Location;
            model.Name = item.Name;
            model.IsActive = item.IsActive;
            return model;
        }

        public int InsertProductionUnit(ProductionUnitAddModel item)
        {
            ProductionUnit model = new ProductionUnit();
            model.Location = item.Location;
            model.Name = item.Name;
            model.IsActive = item.IsActive;
            return productionUnitRepository.Insert(model);
        }

        public int UpdateProductionUnit(ProductUnitUpdateModel productionUnit)
        {
            ProductionUnit eq = productionUnitRepository.Find(p => p.Id == productionUnit.Id);
            eq.Id = productionUnit.Id;
            eq.Name = productionUnit.Name;
            eq.IsActive = productionUnit.IsActive;
            eq.Location = productionUnit.Location;
            return productionUnitRepository.Update(eq);
        }
    }
}
