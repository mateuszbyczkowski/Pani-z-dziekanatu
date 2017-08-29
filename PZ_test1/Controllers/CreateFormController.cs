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
        public ActionResult CreateFormPrzedluzenie(PrzedluzenieSesji wniosek)
        {
            if (ModelState.IsValid)
            {
                wniosek.Status = "Niezatwierdzony";
                _db.PrzedluzenieSesji.Add(wniosek);
                _db.SaveChanges();
                return View("CreateFormPrzedluzenie");
            }
            return View("CreateFormPrzedluzenie", wniosek);
        }

        public ActionResult CreateFormPowtarzanie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFormPowtarzanie(Warunki wniosek)
        {
            if (ModelState.IsValid)
            {
                wniosek.Status = "Niezatwierdzony";
                _db.Warunki.Add(wniosek);
                _db.SaveChanges();
                return View("CreateFormPowtarzanie");
            }
            return View("CreateFormPowtarzanie", wniosek);
        }

        public ActionResult CreateFormLegitymacja()
        {
            return View();
        }
    }
}