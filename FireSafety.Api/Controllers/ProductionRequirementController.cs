using FireSafety.Business;
using FireSafety.DTO.ProductionRequirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FireSafety.Api.Controllers
{
    public class ProductionRequirementController : ApiController
    {
        ProductionRequirementService es = new ProductionRequirementService();
        ProductionUnitService pu = new ProductionUnitService();
        // GET: EquipmentType
        public IHttpActionResult GetAll()
        {
            var gAll = es.GetAllProductionRequirement();
            return Ok(gAll);
        }
        public IHttpActionResult GetById(int id)
        {
            var gId = es.GetProductionRequirementById(id);
            if (gId == null) return NotFound();

            return Ok(gId);
        }
        public IHttpActionResult Delete(int id)
        {
            var gId = es.GetProductionRequirementById(id);
            if (gId == null) return NotFound();
            es.DeleteProductionRequirement(id);
            return Ok();
        }
        public IHttpActionResult Add(ProductionRequirementAddModel eq)
        {
            if (eq == null) return NotFound();


            es.InsertProductionRequiremente(eq);

            return Ok();
        }
        public IHttpActionResult Update(ProductionRequirementUpdateModel eq)
        {
            var gId = es.GetProductionRequirementById(eq.Id);
            if (gId == null) return NotFound();


            var item = es.UpdateProductionRequirement(eq);

            return Ok(item);
        }
        public IHttpActionResult GetAllbyProductionUnitId(int id)
        {
            var gAll = es.GetAllByProductionUniteId(id);
            return Ok(gAll);
        }

    }
}