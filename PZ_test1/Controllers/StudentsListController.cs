using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using PZ_test1;
using PZ_test1.Models;

namespace PZ_test1.Controllers
{
    [Authorize (Roles="Pracownik")]
    public class StudentsListController : Controller
    {
        private DziekanatDbContext _db = new DziekanatDbContext();

        // GET: StudentsList
        public ActionResult Index()
        {
            return View(_db.Students.ToList());
        }

        // GET: StudentsList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = _db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }


        //trzeba zrobić view model który sklei studenta + kierunki + nazwy kierunkow + ectsy + powtarzane przedmioty
        public ActionResult CoursesOfStudy(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var studentProp = (from Stud in _db.Students
            //                   join KierStud in _db.KierunkiStudiow on Stud.Id equals KierStud.StudentId
            //                   select new { KierStud.CoursId, KierStud.Degree, KierStud.Semestr, KierStud.TypeOfStudy }).ToList();

            //var studentProp3 = (from Stud in _db.Students
            //                    join KierStud in _db.KierunkiStudiow on Stud.Id equals KierStud.StudentId
            //                    join PwtPrzed in _db.PowtarzanePrzedmioty on Stud.Id equals PwtPrzed.StudentId.Value
            //                    join ListKier in _db.ListaKierunkow on KierStud.CoursId equals ListKier.Id
            //                    where PwtPrzed.CourseId == ListKier.Id
            //                    select new { ListKier.Id, KierStud.Degree, KierStud.Semestr, KierStud.TypeOfStudy, PwtPrzed.SubjectName, PwtPrzed.ECTS, PwtPrzed.Passed }).ToList();

            //var studentProp1 = (from Stud in _db.Students
            //                    join KierStud in _db.KierunkiStudiow on Stud.Id equals KierStud.StudentId
            //                    join ListKier in _db.ListaKierunkow on KierStud.CoursId equals ListKier.Id
            //                    select new { ListKier.Name, KierStud.Degree, KierStud.Semestr, KierStud.TypeOfStudy }).ToList();

            //var studentProp2 = (from Stud in _db.Students
            //                    join PwtPrzed in _db.PowtarzanePrzedmioty on Stud.Id equals PwtPrzed.StudentId
            //                    join ListKier in _db.ListaKierunkow on PwtPrzed.CourseId equals ListKier.Id
            //                    select new { ListKier.Name, PwtPrzed.ECTS, PwtPrzed.SubjectName, PwtPrzed.Passed }).ToList();

            return View();
        }

        // GET: StudentsList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Passwd,Index,FirstName,SurName,City,Street,Pesel,PostCode,Local")] Students students)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(students);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students);
        }

        // GET: StudentsList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = _db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: StudentsList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Passwd,Index,FirstName,SurName,City,Street,Pesel,PostCode,Local")] Students students)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(students).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: StudentsList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = _db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: StudentsList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = _db.Students.Find(id);
            _db.Students.Remove(students);
            _db.SaveChanges();
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
