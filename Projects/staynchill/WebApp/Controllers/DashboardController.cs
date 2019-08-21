using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }


            if (Session["userRol"].ToString() == "Usuario final")
            {
                return RedirectToAction("Index", "LandingPage");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userViewModel)
        {
            Session["user"] = userViewModel;
            Session["userRol"] = userViewModel.Rol;
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "LandingPage");
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        public ActionResult Hotel()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            EstadoHotelViewModel estadoHotelViewModel = new EstadoHotelViewModel { inHotel = true };
            return View(estadoHotelViewModel);
        }
    }
}