using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PZ_test1;
using PZ_test1.Models;

namespace PZ_test1.Controllers
{
    [Authorize(Roles = "Pracownik")]
    public class PrzedluzanieCzasuRejestracjiController : Controller
    {
        private DziekanatDbContext _db = new DziekanatDbContext();

        // GET: PrzedluzanieCzasuRejestracji
        public ActionResult Index()
        {
            var przedluzanieCzasuRejestracjiSet = _db.PrzedluzenieSesji.Include(p => p.Students);
            return View(przedluzanieCzasuRejestracjiSet.ToList());
        }

        // GET: PrzedluzanieCzasuRejestracji/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrzedluzenieSesji przedluzanieCzasuRejestracjiSet = _db.PrzedluzenieSesji.Find(id);
            if (przedluzanieCzasuRejestracjiSet == null)
            {
                return HttpNotFound();
            }
            return View(przedluzanieCzasuRejestracjiSet);
        }

        // GET: PrzedluzanieCzasuRejestracji/Create
        public ActionResult Create()
        {
            ViewBag.PrzedluzanieCzasuRejestracjiStudents_PrzedluzanieCzasuRejestracji_Id = new SelectList(_db.Students, "Id", "Email");
            return View();
        }

        // POST: PrzedluzanieCzasuRejestracji/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentsId,Imie,Nazwisko,NrLegitymacji,Semestr,Rok,Kierunek,TrybStudiow,Data,Przedmiot,Status,PrzedluzanieCzasuRejestracjiStudents_PrzedluzanieCzasuRejestracji_Id")] PrzedluzenieSesji przedluzanieCzasuRejestracjiSet)
        {
            if (ModelState.IsValid)
            {
                _db.PrzedluzenieSesji.Add(przedluzanieCzasuRejestracjiSet);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(przedluzanieCzasuRejestracjiSet);
        }

        // GET: PrzedluzanieCzasuRejestracji/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrzedluzenieSesji przedluzanieCzasuRejestracjiSet = _db.PrzedluzenieSesji.Find(id);
            if (przedluzanieCzasuRejestracjiSet == null)
            {
                return HttpNotFound();
            }
            return View(przedluzanieCzasuRejestracjiSet);
        }

        // POST: PrzedluzanieCzasuRejestracji/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentsId,Imie,Nazwisko,NrLegitymacji,Semestr,Rok,Kierunek,TrybStudiow,Data,Przedmiot,Status,PrzedluzanieCzasuRejestracjiStudents_PrzedluzanieCzasuRejestracji_Id")] PrzedluzenieSesji przedluzanieCzasuRejestracjiSet)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(przedluzanieCzasuRejestracjiSet).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(przedluzanieCzasuRejestracjiSet);
        }

        // GET: PrzedluzanieCzasuRejestracji/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrzedluzenieSesji przedluzanieCzasuRejestracjiSet = _db.PrzedluzenieSesji.Find(id);
            if (przedluzanieCzasuRejestracjiSet == null)
            {
                return HttpNotFound();
            }
            return View(przedluzanieCzasuRejestracjiSet);
        }

        // POST: PrzedluzanieCzasuRejestracji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrzedluzenieSesji przedluzanieCzasuRejestracjiSet = _db.PrzedluzenieSesji.Find(id);
            if (przedluzanieCzasuRejestracjiSet != null)
                _db.PrzedluzenieSesji.Remove(przedluzanieCzasuRejestracjiSet);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Accept(int? id)
        {
            if (id != null)
            {
                PrzedluzenieSesji wniosekPrzedluzenieSesji = _db.PrzedluzenieSesji.Find(id);
                if (wniosekPrzedluzenieSesji != null) wniosekPrzedluzenieSesji.Status = "Zatwierdzony";
                //_db.Entry(wniosekPrzedluzenieSesji).State = EntityState.Modified;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Reject(int? id)
        {
            if (id != null)
            {
                PrzedluzenieSesji wniosekPrzedluzenieSesji = _db.PrzedluzenieSesji.Find(id);
                if (wniosekPrzedluzenieSesji != null) wniosekPrzedluzenieSesji.Status = "Odrzucony";
                //_db.Entry(wniosekPrzedluzenieSesji).State = EntityState.Modified;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
