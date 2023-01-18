using ItStepSDP211.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItStepSDP211.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext db = new StudentContext();
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(int? id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses = db.Courses.ToList();

            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student, int[] selectedCourses)
        {
            Student newstudent = db.Students.Find(student.Id);
            newstudent.Name = student.Name;

            newstudent.Courses.Clear();

            if(selectedCourses != null)
            {
                foreach (var i in db.Courses.Where(co => selectedCourses.Contains(co.Id)))
                {
                    newstudent.Courses.Add(i);
                }

            }

            db.Entry(newstudent).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

           

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}