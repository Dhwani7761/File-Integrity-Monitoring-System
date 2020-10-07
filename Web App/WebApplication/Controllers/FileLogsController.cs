using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FileLogsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GridDisplay()
        {
            ABCDEntities2 e = new ABCDEntities2();
            var result = (from c in e.FileLogs
                          select new FileLogs 
                          {
                              f_id = c.f_id,
                              f_name = c.f_name,
                              f_path = c.f_path,
                              f_action = c.f_action,
                              f_dtime = c.f_dtime.ToString(),
                              f_hname = c.f_hname
                          }).ToList();
            return View(result);
        }
        
    }
}