using FireSafety.Business;
using FireSafety.Data;
using FireSafety.DTO.ProductionUnit;
using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FireSafety.Api.Controllers
{
    public class ProductionUnitsController : ApiController
    {
        // GET: ProductionUnits
        ProductionUnitService es = new ProductionUnitService();
        // GET: EquipmentType
        public IHttpActionResult GetAll()
        {
            var gAll = es.GetAllProductionUnits();
            return Ok(gAll);
        }
        public IHttpActionResult GetById(int id)
        {
            var gId = es.GetProductionUnitById(id);
            if (gId == null) return NotFound();

            return Ok(gId);
        }
        public IHttpActionResult Delete(int id)
        {
            var gId = es.GetProductionUnitById(id);
            if (gId == null) return NotFound();
            es.DeleteProductionUnit(id);
            return Ok();
        }
        public IHttpActionResult Add(ProductionUnitAddModel eq)
        {

            if (eq == null) return NotFound();
            var item = es.InsertProductionUnit(eq);

            return Ok(item);
        }
        public IHttpActionResult Update(ProductUnitUpdateModel eq, int id)
        {
            if (eq == null) return NotFound();


            var item = es.UpdateProductionUnit(eq);




            return Ok(item);
        }
    }
}