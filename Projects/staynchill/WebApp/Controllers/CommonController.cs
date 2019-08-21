using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.ViewModels;
using System.Threading.Tasks;

namespace WebApp.Controllers
{

    [RoutePrefix("dashboard/binnacle")]
    public class CommonController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

    }
}
