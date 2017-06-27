using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SwimTimeTracker.Models;

namespace SwimTimeTracker.ViewModels
{
    public class AddEventViewModel
    {
        [Required]
        [Display(Name = "Course")]
        public int Course { get; set; }

        [Required]
        [Display(Name = "Stroke")]
        public int Stroke { get; set; }

        [Required]
        [Display(Name = "Distance")]
        public int Distance { get; set; }


        public List<SelectListItem> Courses { get; set; } 
        public List<SelectListItem> Strokes { get; set; } 
        public List<SelectListItem> Distances { get; set; }

        
        public AddEventViewModel() { }

        public AddEventViewModel(IEnumerable<Course> courses, IEnumerable<Stroke> strokes, IEnumerable<Distance> distances)
        
        {
            Courses = new List<SelectListItem>();
            Strokes = new List<SelectListItem>();
            Distances = new List<SelectListItem>();

            foreach (var course in courses)
            {
                Courses.Add(new SelectListItem
                {
                    Value = ((int)course.ID).ToString(),
                    Text = course.Abbr
                });
            }

            foreach (var stroke in strokes)
            {
                Strokes.Add(new SelectListItem
                {
                    Value = ((int)stroke.ID).ToString(),
                    Text = stroke.Abbr
                });
            }

            foreach (var distance in distances)
            {
                Distances.Add(new SelectListItem
                {
                    Value = ((int)distance.ID).ToString(),
                    Text = distance.Length.ToString()
                });

            }

        }

        
    }
}
