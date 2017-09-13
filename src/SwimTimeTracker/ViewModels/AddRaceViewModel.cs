using Microsoft.AspNetCore.Mvc;
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

        //Event does not work without distance select list. See Json. 
        //[Required(ErrorMessage ="Please select an event.")]
        //[Display(Name ="Event")]
        //public int EventID { get; set; }

        //public Event Event { get; set; }

        public int CourseID { get; set; }

        public int StrokeID { get; set; }
                        
        public int DistanceID { get; set; }

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

        // public List<SelectListItem> Events { get; set; }

        public List<SelectListItem> Courses { get; set; }
        public List<SelectListItem> Strokes { get; set; }
        public List<SelectListItem> Distances { get; set; }
        public List<SelectListItem> Events { get; set; }

        //default contstructor
        public AddRaceViewModel() { }

        public AddRaceViewModel(Swimmer swimmer, List<Course> courses, List<Stroke> strokes, List<Distance> distances)
        {
            Courses = new List<SelectListItem>();
            Strokes = new List<SelectListItem>();
            Distances = new List<SelectListItem>();
            Events = new List<SelectListItem>();

            foreach (var course in courses)
            {
                if (course.Abbr != "SCY")
                {
                    Courses.Add(new SelectListItem
                    {
                        Value = ((int)CourseID).ToString(),
                        Text = course.Abbr
                    });
                }
                else
                {
                    Courses.Add(new SelectListItem
                    {
                        Value = ((int)CourseID).ToString(),
                        Text = course.Abbr,
                        Selected = true
                    });
                }
            }

            foreach (var stroke in strokes)
            {
                Strokes.Add(new SelectListItem
                {
                    Value = ((int)StrokeID).ToString(),
                    Text = stroke.Abbr
                });
            }

            foreach (var distance in distances)
            {
                Distances.Add(new SelectListItem
                {
                    Value = ((int)DistanceID).ToString(),
                    Text = distance.Length.ToString()
                });
            }

                    Swimmer = swimmer;
         }

        ////Method for Json to get dependent(3rd)Event Select List.
        ////Doesn't work.  JSON() doesn't exist in this context. 
        ////Also tried in RaceController.  Same problem. 
        //public ActionResult GetDistance(int CourseId, int StrokeId, List<Event> events)
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
        //    return Json(new SelectList(Events, "EventID", "listText"));
        //}
    }
}

