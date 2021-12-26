using FireSafety.DTO.Equipment;
using FireSafety.DTO.ProductionUnit;
using FireSafety.DTO.Reportt;
using FireSafety.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FireSafety.UI.Controllers
{
    public class HomeController : Controller
    {
        HttpService httpService = new HttpService();
        public ActionResult Index()
        {
            List<ProductionUnitListModel> productionUnitList = httpService.getService<List<ProductionUnitListModel>>($"ProductionUnits/getAll");
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Value = "0", Text = "All", Selected = true });
            foreach (var t in productionUnitList)
            {
                selectListItems.Add(new SelectListItem { Value = t.Id.ToString(), Text = t.Name + "-" + t.Location });

            }
           

            ViewBag.ProductionUnitList = new SelectList(selectListItems.ToList(), "Value", "Text");

            ReportListModel model = new ReportListModel();
            model.ControlReportModel = httpService.getService<IEnumerable<ControlReportModel>>($"Reports/getControl/0").ToList();
            model.ReportRequirementModel= httpService.getService<IEnumerable<ReportRequirementModel>>($"Reports/getRequirement/0").ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int Production)
        {
            var selectedValue = Production;
            List<ProductionUnitListModel> productionUnitList = httpService.getService<List<ProductionUnitListModel>>($"ProductionUnits/getAll");
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Value = "0", Text = "All", Selected = (0 == Production) ? true : false } );
            foreach (var t in productionUnitList)
            {
                selectListItems.Add(new SelectListItem { Value = t.Id.ToString(), Text = t.Name + "-" + t.Location, Selected = (t.Id == Production) ? true : false });
            }

            ViewBag.ProductionUnitList = new SelectList(selectListItems.ToList(), "Value", "Text");

            ReportListModel model = new ReportListModel();
            model.ControlReportModel = httpService.getService<IEnumerable<ControlReportModel>>($"Reports/getControl/{Production}").ToList();
            model.ReportRequirementModel = httpService.getService<IEnumerable<ReportRequirementModel>>($"Reports/getRequirement/{Production}").ToList();
            return View(model);

        }

    }
}