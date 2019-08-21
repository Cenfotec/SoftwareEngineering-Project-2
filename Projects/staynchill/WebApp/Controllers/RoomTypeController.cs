using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.ViewModels;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [RoutePrefix("dashboard/roomtypes")]
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class RoomTypeController : Controller
    {
        [Route("")]
        // GET: RoomType
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            EstadoHotelViewModel estadoHotelViewModel = new EstadoHotelViewModel { inHotel = true };
            return View(estadoHotelViewModel);
        }

        // GET: RoomType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// GET: RoomType/create
        /// </summary>
        /// <returns></returns>
        // GET: RoomType/create
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

        // GET: RoomType/Edit/5
        //[Route("roomtype/edit/{id}")]
        [Route("edit")]
        public ActionResult Edit()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            EstadoHotelViewModel estadoHotelViewModel = new EstadoHotelViewModel { inHotel = true };
            return View(estadoHotelViewModel);
        }

        // POST: RoomType/Edit/5
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

        // GET: RoomType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomType/Delete/5
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
