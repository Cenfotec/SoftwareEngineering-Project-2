using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [RoutePrefix("dashboard/Advertisement")]
    public class AdvertisementController : Controller
    {
        // GET: Advertisement
        public ActionResult Index()
        {
            return View();
        }

        // GET: Advertisement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Advertisement/Create
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advertisement/Create
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

        // GET: Advertisement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Advertisement/Edit/5
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

        // GET: Advertisement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Advertisement/Delete/5
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
