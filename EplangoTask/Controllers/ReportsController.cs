using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;

namespace EplangoTask.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
         

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reporting"), MapSelectedReport(id)));
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            rd.Refresh();

            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "report.pdf");
        }

        private string MapSelectedReport(int id)
        {
            switch (id)
            {
                case 1:
                    return "ManagersDepartmentsReport.rpt";
                case 2:
                    return "DepartmentsReport.rpt";
                default:
                    return "ManagersDepartmentsReport.rpt";
            }
        }
    }
}