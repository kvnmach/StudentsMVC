using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Models;

namespace Students.Controllers
{
    public class StudentsController : Controller
    {
        
        public ActionResult Index()
        {
            
            var presentStudents = (List<Student>)Session["students"] ?? new List<Student>();

            Session["students"] = presentStudents;
            return View(presentStudents);



        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student newStudent)
        {
            if (ModelState.IsValid)
            {
                var presentStudents = (List<Student>) Session["students"];
                if (presentStudents == null)
                {
                    presentStudents = new List<Student>();
                }
                presentStudents.Add(newStudent);
                Session["students"] = presentStudents;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {
            List<Student> Students = new List<Student>();
            var editId = Students.FirstOrDefault(s => s.Id == s.Id);
            return View(editId);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            return View();
        }
    }
}