using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [RoutePrefix("dashboard/hotel")]
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            EstadoHotelViewModel estadoHotelViewModel = new EstadoHotelViewModel { inHotel = true };
            return View(estadoHotelViewModel);
        }       

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
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

        // GET: Hotel/Edit/5
        [Route("edit")]
        public ActionResult Edit()
        {
            return View();
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hotel/Delete/5
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
