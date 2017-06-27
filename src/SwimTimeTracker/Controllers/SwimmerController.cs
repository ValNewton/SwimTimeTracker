using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwimTimeTracker.ViewModels;
using SwimTimeTracker.Models;
using SwimTimeTracker.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SwimTimeTracker.Controllers
{
    public class SwimmerController : Controller
    {
        private ApplicationDbContext context;

        public SwimmerController(ApplicationDbContext DbContext)
        {
            context = DbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Swimmer> swimmers = context.Swimmers.ToList();
            return View(swimmers);
        }

        public IActionResult Add()
        {
            AddSwimmerViewModel addSwimmerViewModel = new AddSwimmerViewModel();

            return View(addSwimmerViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddSwimmerViewModel addSwimmerViewModel)
        {
            if (ModelState.IsValid)
            {
                Swimmer newSwimmer = new Swimmer
                {
                    FirstName = addSwimmerViewModel.FirstName,
                    LastName = addSwimmerViewModel.LastName,
                    Gender = addSwimmerViewModel.Gender,
                    BirthYear = addSwimmerViewModel.BirthYear,
                    BirthMonth = addSwimmerViewModel.BirthMonth,
                    BirthDay = addSwimmerViewModel.BirthDay
                };

                context.Swimmers.Add(newSwimmer);
                context.SaveChanges();

                return Redirect("/Index");
                
            }

            return View(addSwimmerViewModel);
        }
    }
}
