using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket_Lois.Controllers
{
    public class NosotrosController : Controller
    {
        // GET: Nosotros
        public ActionResult Index()
        {
            ViewBag.Title = "Sobre Nosotros - Lois's Market";
            return View();
        }
    }
}