using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return RedirectToAction("AdminHotel");
        }

        // GET: Register
        public ActionResult AdminHotel(string id, string Zpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjMZpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjM)
        {
            ViewBag.reqId = id;
            ViewBag.reqPrice = Zpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjMZpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjM;
            return View();
        }
        
        [Route("dashboard/register/adminhotel")]
        public ActionResult AdminHotelActive(string id, string Zpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjMZpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjM)
        {
            ViewBag.reqId = id;
            ViewBag.reqPrice = Zpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjMZpi3Lv2kMB0RzGz5TjMSkRJZ1Y7t10I6jpbHhx2pzjM;
            return View();
        }

    }
}