using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PZ_test1.Models;
namespace PZ_test1.Controllers
{
    [Authorize(Roles = "Student")]
    public class FormListController : Controller
    {
        private DziekanatDbContext _db = new DziekanatDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        // GET: FormList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Warunki()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            
            var wniosekWarunekSet = _db.Warunki.Include(w => w.Students).Where(p=>p.Students.Id == user.Students.Id);
            return View(wniosekWarunekSet.ToList());
        }

        public ActionResult Przedluzenia()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var przedluzanieCzasuRejestracjiSet = _db.PrzedluzenieSesji.Include(p => p.Students).Where(p => p.Students.Id == user.Students.Id);
            return View(przedluzanieCzasuRejestracjiSet.ToList());
        }
    }
}