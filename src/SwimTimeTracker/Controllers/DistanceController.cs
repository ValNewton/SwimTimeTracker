using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SwimTimeTracker.Data;
using SwimTimeTracker.Models;
using SwimTimeTracker.ViewModels;


namespace SwimTimeTracker.Controllers
{
    public class DistanceController : Controller
    {
        private readonly ApplicationDbContext context;

        public DistanceController(ApplicationDbContext DbContext)
        {
            context = DbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Distance> distances = context.Distances.ToList();

            return View(distances);
        }

        public IActionResult Add()
        {
            AddDistanceViewModel addDistanceViewModel = new AddDistanceViewModel();

            return View(addDistanceViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddDistanceViewModel addDistanceViewModel)
        {
            if (ModelState.IsValid)
            {
                Distance newDistance = new Distance
                {
                    Length = addDistanceViewModel.Length
                };
                context.Distances.Add(newDistance);
                context.SaveChanges();

                return View(addDistanceViewModel);
            }

            return View(addDistanceViewModel);
        }
    }
}
