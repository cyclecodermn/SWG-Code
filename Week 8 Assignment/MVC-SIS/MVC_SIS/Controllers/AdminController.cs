using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {
        // /  /   /    /     /      /       /        /          /           /
        // All below are for Majors
        //
        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (string.IsNullOrEmpty(major.MajorName))
            // Check for isNullOrEmpty instead

            {
                ModelState.AddModelError("MajorId",
                    "Please enter the name of the major.");
            }
            if (ModelState.IsValid)
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
            else
            {
                return View(major);
            }
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {

            if (string.IsNullOrEmpty(major.MajorName))
            {
                ModelState.AddModelError("MajorId",
                    "Please enter the name of the major.");
            }
            if (ModelState.IsValid)
            {

                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
            else
            {
                return View(major);
            }
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }


        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        // /  /   /    /     /      /       /        /          /           /
        // All below are for Courses
        //

        [HttpGet]
        public ActionResult Courses()
        {
            var course = CourseRepository.GetAll();
            return View(course.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course Course)
        {
            if (string.IsNullOrEmpty(Course.CourseName))
            // Check for isNullOrEmpty instead

            {
                ModelState.AddModelError("CourseName",
                    "Please enter the name of the course.");
            }


            if (ModelState.IsValid)
            {
                CourseRepository.Add(Course.CourseName);
            return RedirectToAction("Courses");
            }
            else
            {
                return View(Course);
            }
        }

        [HttpPost]
        public ActionResult EditCourse(Course Course)
        {

            if (string.IsNullOrEmpty(Course.CourseName))
            // Check for isNullOrEmpty instead

            {
                ModelState.AddModelError("CourseName",
                    "Please enter the name of the course.");
            }


            if (ModelState.IsValid)
            {
                ////
                ///Add validation to Add Course
                CourseRepository.Edit(Course);
                return RedirectToAction("Courses");
            }
            else
            {
                return View(Course);
            }

        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var Course = CourseRepository.Get(id);
            return View(Course);
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course Course)
        {
            CourseRepository.Delete(Course.CourseId);
            return RedirectToAction("Courses");
        }

        // /  /   /    /     /      /       /        /          /           /
        // All below are for State
        //

        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (string.IsNullOrEmpty(state.StateName))
            {
                ModelState.AddModelError("StateName",
                    "Please enter state name.");
            }
            if (state.StateAbbreviation == null)
            {
                ModelState.AddModelError("StateAbbreviation",
                    "Please enter a state abbreviation.");
            }


            if (ModelState.IsValid)
            {

                StateRepository.Add(state);
                return RedirectToAction("States");
            }
            else
            {
                return View(state);
            }

        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet]
        //public ActionResult EditState(string id)
        //{
        //    State state = StateRepository.Get(id);
        //    return View("State");
        //}

        [HttpGet]
        public ActionResult EditState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }


        [HttpPost]
        public ActionResult EditState(State state)
        {
            if (string.IsNullOrEmpty(state.StateName))
            {
                ModelState.AddModelError("StateName",
                    "Please enter state name.");
            }
            if (state.StateAbbreviation == null)
            {
                ModelState.AddModelError("StateAbbreviation",
                    "Please enter a state abbreviation.");
            }


            if (ModelState.IsValid)
            {
                StateRepository.Edit(state);
                return RedirectToAction("States");
            }
            else
            {
                return View(state);
            }

        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            //State StateToDelete = new State();
            var StateToDelete = StateRepository.Get(id);
            return View(StateToDelete);
        }
        //[HttpGet]
        //public ActionResult DeleteMajor(int id)
        //{
        //    var major = MajorRepository.Get(id);
        //    return View(major);
        //}

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }
    }
}