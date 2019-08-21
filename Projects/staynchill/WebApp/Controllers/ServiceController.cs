using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [RoutePrefix("dashboard/service")]
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ServiceController : Controller
    {
        // GET: Service
        [Route]
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Dashboard");
            }

            EstadoHotelViewModel estadoHotelViewModel = new EstadoHotelViewModel { inHotel = true };
            return View(estadoHotelViewModel);

        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Service/Create
        [Route("create")]
        public ActionResult Create()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            EstadoHotelViewModel estadoHotelViewModel = new EstadoHotelViewModel { inHotel = true };
            return View(estadoHotelViewModel);
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Edit/5
        [Route("edit")]
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
