using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwimTimeTracker.Data;
using SwimTimeTracker.Models;
using SwimTimeTracker.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SwimTimeTracker.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext context;

        public CourseController(ApplicationDbContext DbContext)
        {
            context = DbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Course> courses = context.Courses.ToList();

            return View(courses);
        }

        public IActionResult Add()
        {
            AddCourseViewModel addCourseViewModel = new AddCourseViewModel();

            return View(addCourseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCourseViewModel addCourseViewModel)
        {
            if (ModelState.IsValid)
            {
                Course newCourse = new Course
                {
                    Name = addCourseViewModel.Name,
                    Abbr = addCourseViewModel.Abbr
                };
                context.Courses.Add(newCourse);
                context.SaveChanges();

                return View(addCourseViewModel);
            }

            return View(addCourseViewModel);
        }
    }
}
