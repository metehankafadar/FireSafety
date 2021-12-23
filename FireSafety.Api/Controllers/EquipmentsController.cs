using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireSafety.Business;
using System.Threading.Tasks;
using FireSafety.Business.Interface;
using FireSafety.Entity;
using System.Web.Http.Results;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FireSafety.DTO;
using FireSafety.Data;
using FireSafety.DTO.Equipment;

namespace FireSafety.Api.Controllers
{
   
    public class EquipmentsController : ApiController
    {
        private EquipmentService es = new EquipmentService();

       

        // GET: Equipment
        public IHttpActionResult GetAll()
        {

            var t=es.getAllEquipments();
            return Ok(t);
        }


        
        public IHttpActionResult Delete(int id)
        {
            var equipment = es.GetEquipmentById(id);
            if (equipment == null)
                return NotFound();
            
            es.DeleteEquipment(id);

            return Ok(); //Onay kodu;
            
            
        }




        
        public IHttpActionResult GetById(int id)
        {

            var equipment = es.GetEquipmentById(id);
            if(equipment == null) return NotFound();

            return Ok(equipment);
        }

       
        public IHttpActionResult Add(EquipmentAddModel eq)
        {
            // Equipment equipment =es.InsertEquipment(eq);

            if (eq == null) return NotFound();
            

            var item = es.InsertEquipment(eq);


            return Ok(item);
        }
        
        public IHttpActionResult Update(EquipmentUpdateModel eq)
        {
            if (eq == null)  return NotFound();


            var item = es.UpdateEquipment(eq);




            return Ok(item);
        }

            
        
    }
}