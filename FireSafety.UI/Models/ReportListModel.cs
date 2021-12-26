using FireSafety.DTO.Reportt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireSafety.UI.Models
{
    public class ReportListModel
    {
        public List<ControlReportModel> ControlReportModel {get;set;}
        public List<ReportRequirementModel> ReportRequirementModel { get; set; }
    }
}