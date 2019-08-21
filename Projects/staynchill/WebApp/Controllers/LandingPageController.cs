using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class LandingPageController : Controller
    {
        // GET: LandingPage
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Route("hotels")]
        public ActionResult ListaHoteles()
        {
            return View();
        }

        [Route("hotels/view")]
        public ActionResult VerListaHoteles()
        {
            return View();
        }

        [Route("base")]
        public ActionResult Base()
        {
            return View();
        }
    }
}