using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwimTimeTracker.Data;
using SwimTimeTracker.Models.EventModels;
using SwimTimeTracker.ViewModels;
using SwimTimeTracker.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SwimTimeTracker.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext context;
        
        public EventController(ApplicationDbContext DbContext)
        {
            context = DbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Event> events = context.Events.ToList();

            return View();
        }

        public IActionResult Add()
        {
            //List<Course> courses = context.Courses.ToList();
            //List<Stroke> strokes = context.Strokes.ToList();
            //List<Distance> distances = context.Distances.ToList();

            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
                        
        }


        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                 //var courseID = addEventViewModel.CourseID;

                Course newCourse =
                    context.Courses.Single(c => c.ID == addEventViewModel.Course);
                Stroke newStroke =
                    context.Strokes.Single(s => s.ID == addEventViewModel.Stroke);
                Distance newDistance =
                    context.Distances.Single(d => d.ID == addEventViewModel.Distance);

                Event newEvent = new Event
                {
                    Course = newCourse,
                    Stroke = newStroke,
                    Distance = newDistance
                };

                context.Events.Add(newEvent);
                context.SaveChanges();

                return View(addEventViewModel);
            }

            return View(addEventViewModel);
        }
    }
}
