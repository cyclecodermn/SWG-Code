using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }
        // /  /   /    /     /      /       /        /          /           /
        // I added the methods below by modifying methods from Majors
        //


        //[HttpGet]
        //public ActionResult EditStudent()
        //{
        //    var viewModel = new StudentVM();
        //    viewModel.SetCourseItems(CourseRepository.GetAll());
        //    viewModel.SetMajorItems(MajorRepository.GetAll());
        //    return View(viewModel);
        //}


        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var VMstudent = new StudentVM();
            VMstudent.Student=StudentRepository.Get(id);
            VMstudent.SetMajorItems(MajorRepository.GetAll());
            VMstudent.SetCourseItems(CourseRepository.GetAll());

            //var Student = StudentRepository.Get(id);
            return View(VMstudent);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {

            //var viewModel = new StudentVM();
            //viewModel.SetCourseItems(CourseRepository.GetAll());
            //viewModel.SetMajorItems(MajorRepository.GetAll());
            //return View(viewModel);

            var myVar = student.LastName;
            var VMstudent = new StudentVM();
            VMstudent.Student.StudentId = student.StudentId;
            VMstudent.Student.FirstName = student.FirstName;
            VMstudent.Student.LastName = student.LastName;
            VMstudent.Student.GPA = student.GPA;
            VMstudent.Student.Courses = student.Courses;
                        VMstudent.Student.Major = student.Major;
            int majorId = student.Major.MajorId;
            VMstudent.Student.Major = MajorRepository.Get(majorId);

            StudentRepository.Edit(VMstudent);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var Student = StudentRepository.Get(id);
            return View(Student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student Student)
        {
            StudentRepository.Delete(Student.StudentId);
            return RedirectToAction("List");
        }
    }
}