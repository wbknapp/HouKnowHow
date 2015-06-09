using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouApp_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult MapApp()
        {
            ViewBag.Title = "Map App";

            return View();
        }




        public ActionResult About()
        {
            return View();
        }
    }
}
