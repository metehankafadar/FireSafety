using FireSafety.DTO.Equipment;
using FireSafety.DTO.EquipmentType;
using FireSafety.DTO.ProductionUnit;
using FireSafety.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FireSafety.UI.Controllers
{
    public class EquipmentsController : Controller
    {
        HttpService httpService = new HttpService();
        private string api = "https://localhost:44316/api/Equipments/";
        // GET: Equipment
        public ActionResult Index()
        {
            IEnumerable<EquipmentListModel> result = httpService.getService<IEnumerable<EquipmentListModel>>("equipments/getall");
            return View(result);
        }

        // GET: Equipments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Equipments/Create
        public ActionResult Create()
        {
            List<EquipmentTypeListModel> equipmenttypeList = httpService.getService<List<EquipmentTypeListModel>>($"EquipmentTypes/getAll");

            var EquipmenttypeList = from EquipmentTypeListModel t in equipmenttypeList
                                    select new SelectListItem { Value = t.Id.ToString(), Text = t.Name };

            ViewBag.EquipmenttypeList = new SelectList(EquipmenttypeList.ToList(), "Value", "Text");

            List<ProductionUnitListModel> productionUnitList = httpService.getService<List<ProductionUnitListModel>>($"ProductionUnits/getAll");
            var selectedproList = from ProductionUnitListModel t in productionUnitList
                                  select new SelectListItem { Value = t.Id.ToString(), Text = t.Name + "-" + t.Location};

            ViewBag.ProductionUnitList = new SelectList(selectedproList.ToList(), "Value", "Text");

            return View();
        }

        // POST: Equipments/Create
        [HttpPost]
        public ActionResult Create(EquipmentAddModel equipmentAddModel)
        {
            try
            {
                httpService.postServiceAsync<int,EquipmentAddModel > ("equipments/add", equipmentAddModel); 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipments/Edit/5
        public ActionResult Edit(int id)
        {
            EquipmentListModel result;

                
                //HTTP GET
                result = httpService.getService<EquipmentListModel>($"Equipments/getById/{id}");
              
                List<EquipmentTypeListModel> equipmenttypeList = httpService.getService<List<EquipmentTypeListModel>>($"EquipmentTypes/getAll");
               

                var EquipmenttypeList = from EquipmentTypeListModel t in equipmenttypeList
                                            select new SelectListItem { Value = t.Id.ToString(), Text = t.Name, Selected = (result.EquipmentTypeId == t.Id) ? true : false };
           
                ViewBag.EquipmenttypeList = new SelectList(EquipmenttypeList.ToList(), "Value", "Text");

                List<ProductionUnitListModel> productionUnitList = httpService.getService<List<ProductionUnitListModel>>($"ProductionUnits/getAll");
                var selectedproList = from ProductionUnitListModel t in productionUnitList
                                             select new SelectListItem { Value = t.Id.ToString(), Text = t.Name +"-"+t.Location,Selected= (result.ProductionUnitId == t.Id)?true:false };

                ViewBag.ProductionUnitList = new SelectList(selectedproList.ToList(), "Value", "Text");

            return View(result);
        }

        // POST: Equipments/Edit/5
        [HttpPost]
        public ActionResult Edit(EquipmentListModel equipmentListModel)
        {
            try
            {
                EquipmentUpdateModel updateModel = new EquipmentUpdateModel();
                updateModel.Id = equipmentListModel.Id;
                updateModel.IsAcvite = equipmentListModel.IsAcvite;
                updateModel.EquipmentNo= equipmentListModel.EquipmentNo;
                updateModel.ProductionUnitId = equipmentListModel.ProductionUnitId;
                updateModel.EquipmentTypeId = equipmentListModel.EquipmentTypeId;
                updateModel.ExpirationDate = equipmentListModel.ExpirationDate;
                updateModel.SeriNo = equipmentListModel.SeriNo;
                
                httpService.postServiceAsync<int, EquipmentUpdateModel>($"Equipments/update/{updateModel.Id}", updateModel);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipments/Delete/5
        public ActionResult Delete(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(api);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("delete/"+id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        // POST: Equipments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
