using FireSafety.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FireSafety.Api.Controllers
{
    public class ReportsController : ApiController
    {
        // GET: Report
        public IHttpActionResult getControl(int id)
        {
            ReportService rp = new ReportService();
            var it = rp.getControl(id);
            
            return Ok(it);
        }
        public IHttpActionResult getRequirement(int id)
        {
            ReportService rp = new ReportService();
            var it =   rp.getRequirement(id);
            return Ok(it);
        }
    }
}