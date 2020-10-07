using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AssetModel asset)
        {
            string constr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ABCD;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "INSERT INTO Assets(asset_ip,asset_host,asset_Os,asset_dt,asset_uname) VALUES(@asset_ip, @asset_host,@asset_Os,@asset_dt,@asset_uname)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@asset_ip", asset.ip);
                        cmd.Parameters.AddWithValue("@asset_host", asset.host);
                        cmd.Parameters.AddWithValue("@asset_Os", asset.Os);
                        cmd.Parameters.AddWithValue("@asset_dt", asset.dt);
                        cmd.Parameters.AddWithValue("@asset_uname", asset.uname);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return View(asset);
            }
            catch(Exception ex)
            {
                //throw ex;
                return View("Error");
            }
           
        }
        
        public ActionResult Details()
        {
            ABCDEntities2 e = new ABCDEntities2();
            return View(from FileLogs in e.FileLogs.Take(20) select FileLogs);
        }
        public ActionResult AssetDetails()
        {
            ABCDEntities2 eb = new ABCDEntities2();
            return View(from Asset in eb.Assets.Take(20) select Asset);
        }
        public ActionResult PathDetails()
        {
            ABCDEntities2 ec = new ABCDEntities2();
            return View(from Driver in ec.Drivers.Take(20) select Driver);
        }
    }
}