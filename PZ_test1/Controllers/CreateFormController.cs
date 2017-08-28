using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PZ_test1.Models;

namespace PZ_test1.Controllers
{
    [Authorize(Roles = "Student")]
    public class CreateFormController : Controller
    {
        // GET: CreateForm
        DziekanatDbContext _db = new DziekanatDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateFormPrzedluzenie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFormPrzedluzenie(PrzedluzenieSesji przedluzanie)
        {
            if (ModelState.IsValid)
            {
                przedluzanie.Status = "Niezatwierdzony";
                _db.PrzedluzenieSesji.Add(przedluzanie);
                _db.SaveChanges();
                return View();
            }
            return View("CreateFormPrzedluzenie", przedluzanie);
        }

        public ActionResult CreateFormPowtarzanie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFormPowtarzanie(Warunki warunek)
        {
            
            //ViewBag.Staus = warunek.Status;

            if (ModelState.IsValid)
            {
                
                warunek.Status = "Niezatwierdzony";
                _db.Warunki.Add(warunek);
                _db.SaveChanges();
                return View();
            }
            return View("CreateFormPowtarzanie", warunek);
        }

        public ActionResult CreateFormLegitymacja()
        {
            return View();
        }
    }
}