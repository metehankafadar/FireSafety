using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FireSafety.Business;
using FireSafety.Data;
using FireSafety.DTO.EquipmentControl;
using FireSafety.Entity;

namespace FireSafety.Api.Controllers
{
    public class EquipmentControlsController : ApiController
    {
        private EquipmentControlService ec = new EquipmentControlService();
        // GET: EquipmentControl
        public IHttpActionResult getAll()
        {
            var t = ec.GetAllEquipmentControls();

            return Ok(t);
             
        }
        public IHttpActionResult getById(int id)
        {
            var t = ec.GetEquipmentControlById(id);

            return Ok(t);

        }
        public IHttpActionResult Delete(int id)
        {
            var sil = ec.GetEquipmentControlById(id);
            if (sil == null) return NotFound();
            var t = ec.DeleteEquipmentControl(id);
            return Ok();

        }
        public IHttpActionResult Add(EquipmentControlAddModel eq)
        {

            if (eq == null) return NotFound();
            

            var item = ec.InsertEquipmentControl(eq);

            return Ok(item);

        }
        public IHttpActionResult Update(EquipmentControlUpdateModel eq)
        {
            var sil = ec.GetEquipmentControlById(eq.Id);
            if (sil == null) return NotFound();


            ec.UpdateEquipmentControl(eq);

            return Ok(sil);

        }

        public IHttpActionResult ReadBarcode(String barcode)
        {
            var model = ec.GetEquipmentControlByBarcode(barcode);
            if (model == null) return NotFound();

            return Ok(model);
        }

        public IHttpActionResult GetAllByProductionId(int id)
        {
            var model = ec.GetEquipmentControlByProductionUniteId(id);
            if (model == null) return NotFound();

            return Ok(model);
        }
    }
}
