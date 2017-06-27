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
    public class StrokeController : Controller
    {
        private ApplicationDbContext context;

        public StrokeController(ApplicationDbContext DbContext)
        {
            context = DbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Stroke> strokes = context.Strokes.ToList();

            return View(strokes);
        }

        public IActionResult Add()
        {
            AddStrokeViewModel addStrokeViewModel = new AddStrokeViewModel();

            return View(addStrokeViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddStrokeViewModel addStrokeViewModel)
        {
            if (ModelState.IsValid)
            {
                Stroke newStroke = new Stroke
                {
                    Name = addStrokeViewModel.Name,
                    Abbr = addStrokeViewModel.Abbr
                };
                context.Strokes.Add(newStroke);
                context.SaveChanges();

                return View(addStrokeViewModel);
            }
            return View(addStrokeViewModel);
        }
    }
}
