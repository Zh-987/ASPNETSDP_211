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

        /* List<Student> studentnamesPage;
         public StudentController()
          {
              studentnamesPage = new List<Student>();
              studentnamesPage.Add(new Student {Id = 1, Name = "Adel", Age = 17, Courses})

          }*/



        /*
          
         */
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3;
            IEnumerable<Student> students = db.Students.OrderBy(p =>p.Id).Skip((page-1)*pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Students.Count() };
            IndexViewModel indexView = new IndexViewModel { PageInfo = pageInfo, Students = students };
            return View(indexView);
        
        }
        public ActionResult TemplateExample()
        {
           
            return View();

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
        public ActionResult Input()
        {
            return View();
        }

        [HttpPost]
        public string Input(List<string> names)
        {
            string fin = "";

            for(int i =0;i<names.Count; i++)
            {
                fin += names[i] + "; ";
            }
            return fin; 
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View(db.Students.ToList());
        }
        [HttpPost]
        public string AddStudent(List<Student> student)
        {   
            string studentsName = "";
            for(int i = 0; i < student.Count; i++)
            {
                studentsName += student[i].Name.ToString()+"  ";    
            }
           
            return studentsName; ;
        }

        [HttpGet]
        public ActionResult AddStudentV2()
        {
            Student firststudent = db.Students.ToList<Student>().FirstOrDefault(); 
            return View(firststudent);
        }
        [HttpPost]
        public string AddStudentV2(Student student, Student student1)
        {
            string studentsName = "";
            /*     for (int i = 0; i < student.Count; i++)
                 {
                     studentsName += student[i].Name.ToString() + "  ";
                 }*/

            return studentsName;
        }

        [HttpGet]
        public ActionResult GetCourses()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult GetCourses(Course course)
        { 
            return View();
        }
        public ActionResult StudentText()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudentSearch()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult StudentSearch(string name)
        {
            var allStudents = db.Students.Where(a =>a.Name.Contains(name)).ToList();
            if(allStudents.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allStudents);
        }



    }
}