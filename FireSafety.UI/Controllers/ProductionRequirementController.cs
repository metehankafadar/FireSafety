using FireSafety.DTO.Equipment;
using FireSafety.DTO.EquipmentType;
using FireSafety.DTO.ProductionRequirement;
using FireSafety.DTO.ProductionUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FireSafety.UI.Controllers
{
    public class ProductionRequirementController : Controller
    {
        HttpService httpService = new HttpService();

        // GET: ProductionRequirement
        public ActionResult Index()
        {
            IEnumerable<ProductionRequirementListModel> result = httpService.getService<IEnumerable<ProductionRequirementListModel>>("ProductionRequirement/getall");

            return View(result);
        }
        // GET: ProductionRequirement/Edit/5
        public ActionResult Edit(int id)
        {
            //HTTP GET

            ProductionRequirementListModel result;
            result = httpService.getService<ProductionRequirementListModel>($"ProductionRequirement/getById/{id}");


            List<EquipmentTypeListModel> equipmenttypeList = httpService.getService<List<EquipmentTypeListModel>>($"EquipmentTypes/getAll");


            var EquipmenttypeList = from EquipmentTypeListModel t in equipmenttypeList
                                    select new SelectListItem { Value = t.Id.ToString(), Text = t.Name };

            ViewBag.EquipmenttypeList = new SelectList(EquipmenttypeList.ToList(), "Value", "Text");

            var resulteq = httpService.getService<EquipmentListModel>($"Equipments/getById/{id}");

            List<ProductionUnitListModel> productionunitList = httpService.getService<List<ProductionUnitListModel>>("ProductionUnits/getAll");


            var ProductionUnitList = from ProductionUnitListModel t in productionunitList
                                     select new SelectListItem { Value = t.Id.ToString(), Text = t.Name };
            ViewBag.ProductionunitList = new SelectList(ProductionUnitList.ToList(), "Value", "Text");

            







            return View(result);
        }

        public ActionResult Delete(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("ProductionRequirement/Delete/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }

        }
        public ActionResult Create()
        {

            List<EquipmentTypeListModel> equipmenttypeList = httpService.getService<List<EquipmentTypeListModel>>($"EquipmentTypes/getAll");


            var EquipmenttypeList = from EquipmentTypeListModel t in equipmenttypeList
                                    select new SelectListItem { Value = t.Id.ToString(), Text = t.Name };

            ViewBag.EquipmenttypeList = new SelectList(EquipmenttypeList.ToList(), "Value", "Text");

            //result = httpService.getService<EquipmentListModel>($"Equipments/getById/{id}");

            List<ProductionUnitListModel> productionunitList = httpService.getService<List<ProductionUnitListModel>>("ProductionUnits/getAll");


            var ProductionUnitList = from ProductionUnitListModel t in productionunitList
                                     select new SelectListItem { Value = t.Id.ToString(), Text = t.Name };
            ViewBag.ProductionunitList = new SelectList(ProductionUnitList.ToList(), "Value", "Text");
            return View();
        }

        // POST: Equipments/Create
        [HttpPost]
        public ActionResult Create(ProductionRequirementAddModel productionrequirementAddModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}