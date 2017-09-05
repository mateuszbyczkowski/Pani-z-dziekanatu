using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PZ_test1.Models;
using WebGrease.Css.Extensions;

namespace PZ_test1.Controllers
{
    [Authorize(Roles = "Student")]
    public class CreateFormController : Controller
    {
        DziekanatDbContext _db = new DziekanatDbContext();
        protected UserManager<ApplicationUser> UserManager { get; set; }
        public CreateFormController()
        {
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this._db));
        }
        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        // GET: CreateFor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateFormPrzedluzenie()
        {
            PrzedluzenieSesji wniosek = new PrzedluzenieSesji();
            var student = user.Students;
            wniosek.StudentId = student.Id;
            wniosek.Imie = student.FirstName;
            wniosek.Nazwisko = student.SurName;
            wniosek.NrLegitymacji = student.Index.ToString();
            wniosek.Kierunek = student.KierunkiStudiow.First().ListaKierunkow.Name;
            wniosek.Semestr = student.KierunkiStudiow.First().Semestr;
            wniosek.Status = "Niezatwierdzony";
            wniosek.Przedmiot = student.PowtarzanePrzedmioty.First().SubjectName;
            wniosek.TrybStudiow = student.KierunkiStudiow.First().TypeOfStudy;
            
            return View(wniosek);
        }

        [HttpPost]
        public ActionResult CreateFormPrzedluzenie(PrzedluzenieSesji wniosek)
        {
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    var student = user.Students;
                    if (student != null)
                    {
                        if (!student.PrzedluzeniaSesji.Contains(wniosek))
                        {
                            wniosek.StudentId = student.Id;
                            wniosek.Status = "Niezatwierdzony";
                            _db.PrzedluzenieSesji.Add(wniosek);
                            _db.SaveChanges();
                            ViewBag.result = "Twój formularz został wysłany!";
                            return View("CreateFormPrzedluzenie");
                        }
                        ViewBag.alert = "Nie możesz wysłać dwoch takich samych formularzy!";
                        return View("CreateFormPrzedluzenie");
                    }
                }
            }
            return View("CreateFormPrzedluzenie", wniosek);
        }

        public ActionResult CreateFormPowtarzanie()
        {
            Warunki wniosek = new Warunki();
            var student = user.Students;
            wniosek.StudentsId = student.Id;
            wniosek.Imie = student.FirstName;
            wniosek.Nazwisko = student.SurName;
            wniosek.NrLegitymacji = student.Index.ToString();
            wniosek.Kierunek = student.KierunkiStudiow.First().ListaKierunkow.Name;
            wniosek.Semestr = student.KierunkiStudiow.First().Semestr;
            wniosek.Status = "Niezatwierdzony";
            wniosek.Przedmiot = student.PowtarzanePrzedmioty.First().SubjectName;
            wniosek.TrybStudiow = student.KierunkiStudiow.First().TypeOfStudy;
            wniosek.ECTS = student.PowtarzanePrzedmioty.First().ECTS.ToString();
            
            return View(wniosek);
        }

        [HttpPost]
        public ActionResult CreateFormPowtarzanie(Warunki wniosek)
        {
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    var student = user.Students;
                    if (student != null)
                    {
                        if (student.Warunki.Contains(wniosek))
                        {
                            ViewBag.alert = "Nie możesz wysłać dwoch takich samych formularzy!";
                            return View("CreateFormPowtarzanie");
                        }
                        wniosek.StudentsId = student.Id;
                        wniosek.Status = "Niezatwierdzony";
                        _db.Warunki.Add(wniosek);
                        _db.SaveChanges();
                        ViewBag.result = "Twój formularz został wysłany!";
                        return View("CreateFormPowtarzanie");
                    }
                }
            }
            return View("CreateFormPowtarzanie", wniosek);
        }

        public ActionResult CreateFormLegitymacja()
        {
            return View();
        }

        public ActionResult TakeDate(int? id)
        {
            if (id != null)
            {
                switch (id)
                {
                    case 1:
                    { 
                        ViewBag.Date1 = "Zarezerwowano";
                        break;
                    }
                    case 2:
                    {
                        ViewBag.Date2 = "Zarezerwowano";
                        break;
                    }
                    case 3:
                    {
                        ViewBag.Date3 = "Zarezerwowano";
                        break;
                    }
                    case 4:
                    {
                        ViewBag.Date4 = "Zarezerwowano";
                        break;
                    }
                    case 5:
                    {
                        ViewBag.Date5 = "Zarezerwowano";
                        break;
                    }
                    case 6:
                    {
                        ViewBag.Date6 = "Zarezerwowano";
                        break;
                    }
                    case 7:
                    {
                        ViewBag.Date7 = "Zarezerwowano";
                        break;
                    }
                    case 8:
                    {
                        ViewBag.Date8 = "Zarezerwowano";
                        break;
                    }
                    case 9:
                    {
                        ViewBag.Date9 = "Zarezerwowano";
                        break;
                    }
                    case 10:
                    {
                        ViewBag.Date10 = "Zarezerwowano";
                        break;
                    }
                    case 11:
                    {
                        ViewBag.Dateb1 = "Zarezerwowano";
                        break;
                    }
                    case 12:
                    {
                        ViewBag.Dateb2 = "Zarezerwowano";
                        break;
                    }
                    case 13:
                    {
                        ViewBag.Dateb3 = "Zarezerwowano";
                        break;
                    }
                    case 14:
                    {
                        ViewBag.Dateb4 = "Zarezerwowano";
                        break;
                    }
                    case 15:
                    {
                        ViewBag.Dateb5 = "Zarezerwowano";
                        break;
                    }
                    case 16:
                    {
                        ViewBag.Dateb6 = "Zarezerwowano";
                        break;
                    }
                    case 17:
                    {
                        ViewBag.Dateb7 = "Zarezerwowano";
                        break;
                    }
                    case 18:
                    {
                        ViewBag.Dateb8 = "Zarezerwowano";
                        break;
                    }
                    case 19:
                    {
                        ViewBag.Dateb9 = "Zarezerwowano";
                        break;
                    }
                    case 20:
                    {
                        ViewBag.Dateb10 = "Zarezerwowano";
                        break;
                    }
                }
            }
            return View("CreateFormLegitymacja");
        }
    }
}