using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Business.Interface
{
    public interface IProductionRequirementService
    {
        List<ProductionRequirement> GetAllProductionRequirement();
        int InsertProductionRequiremente(ProductionRequirement productionRequirement);
        ProductionRequirement GetProductionRequirementById(int id);
        int UpdateProductionRequirement(ProductionRequirement productionRequirement, int id);
        int DeleteProductionRequirement(ProductionRequirement productionRequirement);
    }
}
