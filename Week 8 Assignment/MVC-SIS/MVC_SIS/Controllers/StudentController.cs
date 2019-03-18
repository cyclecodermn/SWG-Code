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
            viewModel.SetStateItems(StateRepository.GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            
            if (string.IsNullOrEmpty(studentVM.Student.FirstName))
            {
                ModelState.AddModelError("Student.FirstName",
                    "Please enter the student's first name.");
            }

            if (string.IsNullOrEmpty(studentVM.Student.LastName))
            {
                ModelState.AddModelError("Student.LastName",
                    "Please enter the student's last name.");
            }

            if (studentVM.Student.GPA < 0 || studentVM.Student.GPA > 4)
            {
                ModelState.AddModelError("Student.GPA", "Please enter a GPA between zero and four.");
            }

            if (studentVM.SelectedCourseIds.Count() == 0)
            {
                ModelState.AddModelError("Student.Courses",
                    "Please select at least one course.");
            }

            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();
                string studentStateAbb = studentVM.Student.Address.State.StateAbbreviation;
                studentVM.Student.Address.State = StateRepository.Get(studentStateAbb);
                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");

            }
            else
            {
                // send them back to the entry form
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetStateItems(StateRepository.GetAll());
                return View(studentVM);
            }
        }
        // /  /   /    /     /      /       /        /          /           /
        // I added the methods below by modifying methods from Majors
        //

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var VMstudent = new StudentVM();

            VMstudent.Student = StudentRepository.Get(id);
            VMstudent.SetMajorItems(MajorRepository.GetAll());
            VMstudent.SetCourseItems(CourseRepository.GetAll());
            VMstudent.SetStateItems(StateRepository.GetAll());

            if (((VMstudent.Student.Courses?.Count) ?? 0) > 0)
            // If .count succeeeds, then the if condition is true. The questions marks are ignoried, and the
            // the statement below is run.
            // If the .count fails, courses, is null, the entire statement:
            // (VMstudent.Student.Courses?.Count) is set to null. THEN ?? which is null coalessing comes into play.
            // That will say if the left is null, make everyhing on the left of ? bcomes zero, which can be compared 
            // to > 0.
            {
                VMstudent.SelectedCourseIds = (from course in VMstudent.Student.Courses select course.CourseId).ToList();
            }
            else
            {
                VMstudent.SelectedCourseIds = new List<int>();
            }

            //var Student = StudentRepository.Get(id);
            return View(VMstudent);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM studentVM)
        {

            if (string.IsNullOrEmpty(studentVM.Student.FirstName))
            {
                ModelState.AddModelError("Student.FirstName",
                    "Please enter the student's first name.");
            }

            if (string.IsNullOrEmpty(studentVM.Student.LastName))
            {
                ModelState.AddModelError("Student.LastName",
                    "Please enter the student's last name.");
            }

            if (studentVM.Student.GPA < 0 || studentVM.Student.GPA > 4)
            {
                ModelState.AddModelError("Student.GPA", "Please enter a GPA between zero and four.");
            }

            if (studentVM.SelectedCourseIds.Count() == 0)
            {
                ModelState.AddModelError("Student.Courses",
                    "Please select at least one course.");
            }

                if (ModelState.IsValid)
            {
                int majorId = studentVM.Student.Major.MajorId;
                studentVM.Student.Major = MajorRepository.Get(majorId);
                studentVM.Student.Address.State = StateRepository.Get(studentVM.Student.Address.State.StateAbbreviation);
                studentVM.Student.Courses = CourseRepository.GetAll().Where(c => studentVM.SelectedCourseIds.Contains(c.CourseId)).ToList();
                StudentRepository.Edit(studentVM.Student);
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
                return RedirectToAction("List");
            }
            else
            {
                // send them back to the entry form
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetStateItems(StateRepository.GetAll());
                return View(studentVM);
            }
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