using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwimTimeTracker.Data;
using SwimTimeTracker.Models;
using SwimTimeTracker.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;


namespace SwimTimeTracker.Controllers
{
    public class RaceController : Controller
    {
        private ApplicationDbContext context;

        public RaceController(ApplicationDbContext DbContext)
        {
            context = DbContext;
        }

        public int EventID { get; set; }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            //??not sure if this works yet.//
            IList<Race> races = context.Races.Include(
                r => r.Swimmer).Include(
                r => r.Event).
                ToList();

            return View(races);
        }

        public IActionResult Add(int id)
        {
            Swimmer swimmer = context.Swimmers.Single(s => s.Id == id);

            List<Course> courses = context.Courses.ToList();
            List<Stroke> strokes = context.Strokes.ToList();
            List<Distance> distances = context.Distances.ToList();

            //Event not currently included.  Cascading Select list not working.
            //Events to be displayed with distance property(event.distanceID.Length)

            //AddRaceViewModel addRaceViewModel = new AddRaceViewModel(swimmer,
            // context.Events.ToList());

            return View(new AddRaceViewModel(swimmer,courses,strokes,distances));
        }

        [HttpPost]
        public IActionResult Add(AddRaceViewModel addRaceViewModel)
        {
            if (ModelState.IsValid)
            {
                Swimmer thisSwimmer =
                    context.Swimmers.Single(s => s.Id == addRaceViewModel.SwimmerID);
                
                Course thisCourse =
                    context.Courses.Single(c => c.ID == addRaceViewModel.CourseID);

               Stroke thisStroke =
                    context.Strokes.Single(s => s.ID == addRaceViewModel.StrokeID);

                Distance thisDistance =
                    context.Distances.Single(d => d.ID == addRaceViewModel.DistanceID);

                //Event thisEvent =
                //    context.Events.Single(e => e.ID == addRaceViewModel.EventID);

                int hh = addRaceViewModel.hund;
                
                int ss = addRaceViewModel.sec;
                
                int mm = addRaceViewModel.min;

                TimeSpan thisTime = new TimeSpan(mm,ss,hh);

                int year = addRaceViewModel.year;
                int mth = addRaceViewModel.mth;
                int day = addRaceViewModel.day;

                DateTime thisDate = new DateTime(year, mth, day);


                Race newRace = new Race
                {
                    Swimmer = thisSwimmer,
                    //Event = thisEvent,
                    RaceTime = thisTime,
                    DateTime = thisDate
                };
                
                context.Races.Add(newRace);
                context.SaveChanges();

                return View(addRaceViewModel);
            }

            return View(addRaceViewModel);
        }
        
        //Json method does not work.  Json() does not exist in this context. // 
        //Also tried this code in ViewModel. //

        //public JsonResult GetDistance(int CourseId, int StrokeId, List<Event> events)
        //{
        //    foreach (var e in events)
        //    {
        //        if (e.CourseID == CourseId && e.StrokeID == StrokeId)
        //        {
        //            string listText = Event.DistanceID.ToString();

        //            Events.Add(new SelectListItem
        //            {
        //                Value = ((int)EventID).ToString(),
        //                Text = listText
        //            });
        //        }
        //        else
        //        { }
        //    }
        //    return Json(new SelectList(EventId, "EventED", "listText"));
        //}

    }
}

