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
    public class WniosekWarunekController : Controller
    {
        private DziekanatDbContext _db = new DziekanatDbContext();

        // GET: WniosekWarunek
        public ActionResult Index()
        {
            var wniosekWarunek = _db.Warunki.Include(w => w.Students);
            return View(wniosekWarunek.ToList());
        }

        // GET: WniosekWarunek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warunki wniosekWarunek = _db.Warunki.Find(id);
            if (wniosekWarunek == null)
            {
                return HttpNotFound();
            }
            return View(wniosekWarunek);
        }

        // GET: WniosekWarunek/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(_db.Students, "Id", "Email");
            return View();
        }

        // POST: WniosekWarunek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentsId,Imie,Nazwisko,NrLegitymacji,Semestr,Rok,Kierunek,TrybStudiow,Data,Przedmiot,ECTS,TerminZaliczenia,Status")] Warunki wniosekWarunek)
        {
            if (ModelState.IsValid)
            {
                _db.Warunki.Add(wniosekWarunek);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(_db.Students, "Id", "Email", wniosekWarunek.Id);
            return View(wniosekWarunek);
        }

        // GET: WniosekWarunek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warunki wniosekWarunek = _db.Warunki.Find(id);
            if (wniosekWarunek == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(_db.Students, "Id", "Email", wniosekWarunek.Id);
            return View(wniosekWarunek);
        }

        // POST: WniosekWarunek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentsId,Imie,Nazwisko,NrLegitymacji,Semestr,Rok,Kierunek,TrybStudiow,Data,Przedmiot,ECTS,TerminZaliczenia,Status")] Warunki wniosekWarunek)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(wniosekWarunek).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(_db.Students, "Id", "Email", wniosekWarunek.Id);
            return View(wniosekWarunek);
        }

        // GET: WniosekWarunek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warunki wniosekWarunek = _db.Warunki.Find(id);
            if (wniosekWarunek == null)
            {
                return HttpNotFound();
            }
            return View(wniosekWarunek);
        }

        // POST: WniosekWarunek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warunki wniosekWarunek = _db.Warunki.Find(id);
            _db.Warunki.Remove(wniosekWarunek);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Accept(int? id)
        {
            if (id != null)
            {
                Warunki wniosekWarunek = _db.Warunki.Find(id);
                if (wniosekWarunek != null) wniosekWarunek.Status = "Zatwierdzony";
                //_db.Entry(wniosekWarunek).State = EntityState.Modified;
                _db.SaveChanges();
            }
           return RedirectToAction("Index");
        }

        public ActionResult Reject(int? id)
        {
            if (id != null)
            {
                Warunki wniosekWarunek = _db.Warunki.Find(id);
                if (wniosekWarunek != null) wniosekWarunek.Status = "Odrzucony";
                //_db.Entry(wniosekWarunek).State = EntityState.Modified;
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
