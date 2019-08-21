using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [RoutePrefix("dashboard/hotel2")]
    public class Hotel2Controller : Controller
    {
        // GET: Hotel
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
