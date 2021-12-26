using FireSafety.DTO;
using FireSafety.DTO.Equipment;
using FireSafety.DTO.EquipmentControl;
using FireSafety.DTO.EquipmentType;
using FireSafety.DTO.ProductionUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FireSafety.UI.Controllers
{
    public class EquipmentControlsController : Controller
    {
        HttpService httpService = new HttpService();
        // GET: EquipmentControls
        public ActionResult Index()
        {
            
            IEnumerable<EquipmentControlListModel> result = httpService.getService<IEnumerable<EquipmentControlListModel>>("EquipmentControls/getall");
            return View(result);
        }
        // GET: EquipmentControl/Edit/5
        public ActionResult Edit(int id)
        {
            EquipmentControlListModel result;


            //HTTP GET
            result = httpService.getService<EquipmentControlListModel>($"EquipmentControls/getById/{id}");

            List<EquipmentTypeListModel> equipmenttypeList = httpService.getService<List<EquipmentTypeListModel>>($"EquipmentTypes/getAll");


            var EquipmenttypeList = from EquipmentTypeListModel t in equipmenttypeList
                                    select new SelectListItem { Value = t.Id.ToString(), Text = t.Name };

            ViewBag.EquipmenttypeList = new SelectList(EquipmenttypeList.ToList(), "Value", "Text");

            List<ProductionUnitListModel> productionUnitList = httpService.getService<List<ProductionUnitListModel>>($"ProductionUnits/getAll");
            var selectedproList = from ProductionUnitListModel t in productionUnitList
                                  select new SelectListItem { Value = t.Id.ToString(), Text = t.Name };

            ViewBag.ProductionUnitList = new SelectList(selectedproList.ToList(), "Value", "Text");


            return View(result);
        }
        // GET: EquipmentControl/Create
        [HttpPost]
        public ActionResult Create(EquipmentControlAddModel equipmentAddModel)
        {
            try
            {
       

                httpService.postServiceAsync<int, EquipmentControlAddModel>("EquipmentControls/Add", equipmentAddModel);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }


        }
        // GET: EquipmentControl/Create
        public ActionResult Create()
        {
        
            List<EquipmentListModel> equipmentList = httpService.getService<List<EquipmentListModel>>($"Equipments/getAll");


            var EquipmentList = from EquipmentListModel t in equipmentList
                                select new SelectListItem { Value = t.Id.ToString(), Text = t.SeriNo + "-"+ t.EquipmentTypeName};

            ViewBag.EquipmentList = new SelectList(EquipmentList.ToList(), "Value", "Text");
            return View();
        }

        public ActionResult Delete(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("EquipmentControls/Delete/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}