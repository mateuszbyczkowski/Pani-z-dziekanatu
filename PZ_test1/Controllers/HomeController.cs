using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PZ_test1.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Student")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Twórcy aplikacji";

            return View();
        }
    }
}

//fix w klasie kontekstu 
//public virtual Models.ApplicationUser ApplicationUser { get; set; }