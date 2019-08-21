using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [RoutePrefix("dashboard/subadministrators")]
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class SubadministratorController : Controller
    {
        // GET: Subadministrator
        [Route]
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Dashboard");
            }

            //if (userListViewModel.Data != null)
            //{
            //    TempData["userList"] = userListViewModel;
            //    return RedirectToAction("Index", userListViewModel);
            //}
            

            EstadoHotelViewModel estadoHotelViewModel = new EstadoHotelViewModel { inHotel = true };
            return View(estadoHotelViewModel);
        }

        // GET: Subadministrator/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("create")]
        // GET: Subadministrator/Create
        public ActionResult Create()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            EstadoHotelViewModel estadoHotelViewModel = new EstadoHotelViewModel { inHotel = true };
            return View(estadoHotelViewModel);
        }

        // POST: Subadministrator/Create
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

        // GET: Subadministrator/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Subadministrator/Edit/5
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

        // GET: Subadministrator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subadministrator/Delete/5
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
