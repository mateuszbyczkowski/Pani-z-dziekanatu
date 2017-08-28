using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PZ_test1.Controllers
{
    [Authorize(Roles = "Pracownik")]
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Drogi pracowniku ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Twórcy aplikacji";

            return View();
        }
    }
}