using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.ViewModels;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [RoutePrefix("dashboard/nullproduct")]
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ProductController : Controller
    {
        // GET: Product
        [Route]
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Dashboard");
            }

            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// GET: /dashboard/Product/Create
        /// </summary>
        /// <returns></returns>
        [Route("create")]
        public ActionResult Create()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Dashboard");
            }

            return View();
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        //[Route("product/edit/{id}")]
        [Route("edit")]
        public ActionResult Edit()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Dashboard");
            }

            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
