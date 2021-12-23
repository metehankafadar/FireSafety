using FireSafety.Business;
using FireSafety.Data;
using FireSafety.DTO.EquipmentType;
using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FireSafety.Api.Controllers
{
    public class EquipmentTypesController : ApiController
    {
        EquipmentTypeService es = new EquipmentTypeService(); 
        // GET: EquipmentType
        public IHttpActionResult GetAll()
        {
            var gAll = es.GetAllEquipmentType(); 
            return Ok(gAll);
        }
        public IHttpActionResult GetById(int id)
        {
            var gId = es.GetEquipmentTypeById(id);
            if (gId == null) return NotFound();

            return Ok(gId);
        }
        public IHttpActionResult Delete(int id)
        {
            var gId = es.GetEquipmentTypeById(id);
            if (gId == null) return NotFound();
            es.DeleteEquipmentType(id);
            return Ok();
        }
        public IHttpActionResult Add(EquipmentTypeAddModel eq)
        {
            if (eq == null) return NotFound();
            
          
            var item = es.InsertEquipmentType(eq);

            return Ok(item);
        }
        public IHttpActionResult Update(EquipmentTypeUpdateModel eq)
        {
            var gId = es.GetEquipmentTypeById(eq.Id);
            if (gId == null) return NotFound();


           var item = es.UpdateEquipmentType(eq);

            return Ok(item);
        }
    }
}