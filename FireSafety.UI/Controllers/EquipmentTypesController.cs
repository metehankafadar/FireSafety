
using FireSafety.DTO.EquipmentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FireSafety.UI.Controllers
{
    public class EquipmentTypesController : Controller
    {
        HttpService httpService = new HttpService();

        // GET: EquipmentTypeControl
        public ActionResult Index()
        {
            IEnumerable<EquipmentTypeListModel> result = httpService.getService<IEnumerable<EquipmentTypeListModel>>("EquipmentTypes/getall");
            return View(result);
            
        }

        // GET: EquipmentType/Edit/5
        public ActionResult Edit(int id)
        {
            EquipmentTypeListModel result;


            //HTTP GET
            result = httpService.getService<EquipmentTypeListModel>($"EquipmentTypes/getById/{id}");


            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(EquipmentTypeUpdateModel equipmenttypeUpdateModel)
        {
            int id = equipmenttypeUpdateModel.Id;


            //HTTP GET
            httpService.postServiceAsync<int, EquipmentTypeUpdateModel>($"EquipmentTypes/Update/{id}", equipmenttypeUpdateModel);


            return RedirectToAction("Index");
        }

        // GET: EquipmentType/Create
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(EquipmentTypeAddModel equipmentTypeAddModel)
        {
            try
            {
                EquipmentTypeAddModel addModel = new EquipmentTypeAddModel();
                addModel.IsActived = equipmentTypeAddModel.IsActived;
                addModel.Name = equipmentTypeAddModel.Name;
                httpService.postServiceAsync<int, EquipmentTypeAddModel>("EquipmentTypes/Add", addModel);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("EquipmentTypes/Delete/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            
        }
    }
}