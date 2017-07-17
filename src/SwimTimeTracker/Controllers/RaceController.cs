  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwimTimeTracker.Data;
using SwimTimeTracker.Models;
using SwimTimeTracker.ViewModels;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SwimTimeTracker.Controllers
{
    public class RaceController : Controller
    {
        private ApplicationDbContext context;

        public RaceController(ApplicationDbContext DbContext)
        {
            context = DbContext;
        }
        
                // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Race> races = context.Races.Include(
                r => r.Swimmer).Include(
                r => r.Event).
                ToList();

            return View(races);
        }

        public IActionResult Add(int id)
        {
            Swimmer swimmer = context.Swimmers.Single(s => s.Id == id);

            List<Event> events = context.Events.ToList();

            //AddRaceViewModel addRaceViewModel = new AddRaceViewModel(swimmer,
               // context.Events.ToList());
               
            return View(new AddRaceViewModel(swimmer, events));

            //AddRaceViewModel addRaceViewModel = new AddRaceViewModel(
            //    int id,
            //    context.Events.ToList());

            //AddRaceViewModel addRaceViewModel = new AddRaceViewModel(
            //    context.Swimmers.ToList(),
            //    context.Events.ToList());
                         
        }


        [HttpPost]
        public IActionResult Add(AddRaceViewModel addRaceViewModel)
        {
            if (ModelState.IsValid)
            {
                Swimmer thisSwimmer =
                    context.Swimmers.Single(s => s.Id == addRaceViewModel.SwimmerID);
                //Event thisEvent =
                  //  context.Events.Single(e => e.ID == addRaceViewModel.EventID);

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
                    Event = thisEvent,
                    RaceTime = thisTime,
                    DateTime = thisDate
                };
                
                context.Races.Add(newRace);
                context.SaveChanges();

                return View(addRaceViewModel);
            }

            return View(addRaceViewModel);

        }
    }
}
