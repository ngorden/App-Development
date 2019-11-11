using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationDevelopment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bakery Purpose.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact the sisters.";

            return View();
        }
    }
}