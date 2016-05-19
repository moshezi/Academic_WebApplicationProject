using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Who We Are?";
            ViewBag.backgroundID = "office";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact US";

            return View();
        }
    }
}