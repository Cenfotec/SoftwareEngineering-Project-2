using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.ViewModels;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class UserController : Controller
    {
        // create
        [Route("register/plataforma")]
        public ActionResult Create()
        {
            return View();
        }
        // index
        [Route("dashboard/users")]
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        [Route("register")]
        public ActionResult CreateUserFinal()
        {

            return View();
        }

        [Route("user/edit")]
        public ActionResult EditUserFinal()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }
    }
}
