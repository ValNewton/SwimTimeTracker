using Microsoft.AspNetCore.Mvc.Rendering;
using SwimTimeTracker.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwimTimeTracker.ViewModels
{
    public class AddRaceViewModel
    {
        public Swimmer Swimmer { get; set; }

        [Required]
        [Display(Name = "Swimmer")]
        public int SwimmerID { get; set; }

        [Required(ErrorMessage ="Please select an event.")]
        [Display(Name ="Event")]
        public int EventID { get; set; }

        [Range(0, 99, ErrorMessage = "Enter 2 digits maximum for minutes")]
        [Display(Name = "Minutes")]
        public int min { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "Enter 2 digits maximum for seconds")]
        [Display(Name = "Seconds")]
        public int sec { get; set; }

        [Range(0, 99, ErrorMessage = "Enter 2 digits maximum for hundreds")]
        [Display(Name = "Hundreds")]
        public int hund { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int year { get; set; }

        [Required]
        [Display(Name = "Month")]
        public int mth { get; set; }

        [Required]
        [Display(Name = "Day")]
        public int day { get; set; }

        public List<SelectListItem> Events { get; set; }
        
        //public List<SelectListItem> Events.Courses { get; set; }
        //public List<SelectListItem> Events.Strokes { get; set; }
        //public List<SelectListItem> Events.Distances { get; set; }

        //default contstructor
        public AddRaceViewModel() { }
        
        public AddRaceViewModel(Swimmer swimmer, IEnumerable<Event> events)
        {
            Events = new List<SelectListItem>();

            foreach (var event_ in events)
            {
                Events.Add(new SelectListItem
                {
                    Value = ((int)EventID).ToString(),
                   // Value = ((int)event.ID).ToString(),
                    //Text = "event"        
                    Text = "test"  //replace with text for event**
                });
        }
            Swimmer = swimmer;
        }
    }
}

