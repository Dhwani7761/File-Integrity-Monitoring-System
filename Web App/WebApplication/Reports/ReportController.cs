using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication.Reports
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        DataSet1 ds = new DataSet1();
        public ActionResult Report1()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);

        
            String constr = @"Data Source = .\SQLEXPRESS; Initial Catalog = ABCD; Integrated Security = True; MultipleActiveResultSets = True; Application Name = EntityFramework";
        
            SqlConnection conx = new SqlConnection(constr);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM FileLogs", conx);

            adp.Fill(ds, ds.FileLogs.TableName);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Report1.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables[0]));


            ViewBag.ReportViewer = reportViewer;

            return View();
        }
    }
}