using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Business.Interface
{
    public interface IProductionUnitService
    {
        List<ProductionUnit> GetAllProductionUnits();
        int InsertProductionUnit(ProductionUnit productionUnit);
        ProductionUnit GetProductionUnitById(int id);
        int UpdateProductionUnit(ProductionUnit productionUnit, int id);
        int DeleteProductionUnit(ProductionUnit productionUnit);

    }
}
