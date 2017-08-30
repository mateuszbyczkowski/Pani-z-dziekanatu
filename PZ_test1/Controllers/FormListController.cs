using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PZ_test1.Models;
namespace PZ_test1.Controllers
{
    [Authorize(Roles = "Student")]
    public class FormListController : Controller
    {
        private DziekanatDbContext _db = new DziekanatDbContext();

        public ApplicationUser _user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        // GET: FormList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Warunki()
        {
            var wniosekWarunek = _db.Warunki.Include(w => w.Students).Where(p=>p.Students.Id == _user.Students.Id);
            return View(wniosekWarunek.ToList());
        }

        public ActionResult Przedluzenia()
        {
            var przedluzanieCzasuRejestracji = _db.PrzedluzenieSesji.Include(w => w.Students).Where(p => p.Students.Id == _user.Students.Id);
            return View(przedluzanieCzasuRejestracji.ToList());
        }
    }
}