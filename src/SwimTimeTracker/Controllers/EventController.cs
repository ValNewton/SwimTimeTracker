using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SwimTimeTracker.Data;
using SwimTimeTracker.ViewModels;
using SwimTimeTracker.Models;
using Microsoft.EntityFrameworkCore;



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
            IList<Event> events = context.Events.Include(
                e => e.Course).Include(
                e => e.Stroke).Include(
                e => e.Distance).
                ToList();
            //IList<Event> events = context.Events.ToList();

            return View(events);
        }

        public IActionResult Add()
        {            
            AddEventViewModel addEventViewModel = new AddEventViewModel(
                context.Courses.ToList(),
                context.Strokes.ToList(),
                context.Distances.ToList());

            return View(addEventViewModel);
        }


        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Course newCourse =
                    context.Courses.Single(c => c.ID == addEventViewModel.CourseID);
                Stroke newStroke =
                    context.Strokes.Single(s => s.ID == addEventViewModel.StrokeID);
                Distance newDistance =
                    context.Distances.Single(d => d.ID == addEventViewModel.DistanceID);

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
