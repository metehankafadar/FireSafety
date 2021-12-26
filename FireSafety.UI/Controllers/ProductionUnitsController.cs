using FireSafety.DTO.ProductionUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FireSafety.UI.Controllers
{
    public class ProductionUnitsController : Controller
    {
        HttpService httpService = new HttpService();
        // GET: ProductionUnit
        public ActionResult Index()
        {
            IEnumerable<ProductionUnitListModel> result = httpService.getService<IEnumerable<ProductionUnitListModel>>("ProductionUnits/getall");

            return View(result);
        }
        // GET: ProductionUnit/Edit/5
        public ActionResult Edit(int id)
        {
            ProductionUnitListModel result;


            //HTTP GET
            result = httpService.getService<ProductionUnitListModel>($"ProductionUnits/getById/{id}");


            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(ProductionUnitAddModel productionUnitUpdateModel)
        {
            int id = productionUnitUpdateModel.Id;


            //HTTP GET
            httpService.postServiceAsync<int, ProductionUnitAddModel>($"ProductionUnits/Update/{id}", productionUnitUpdateModel);


            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("ProductionUnits/Delete/" + id.ToString());
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
            return View();
        }

        // POST: Equipments/Create
        [HttpPost]
        public ActionResult Create(ProductionUnitAddModel productionUnitAddModel)
        {
            try
            {
                
                httpService.postServiceAsync<int, ProductionUnitAddModel>("ProductionUnits/Add", productionUnitAddModel);
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