using Microsoft.AspNetCore.Mvc.Rendering;
using SwimTimeTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwimTimeTracker.ViewModels
{
    public class AddSwimmerViewModel
    {
        [Required(ErrorMessage = "You must give a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must give a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select a gender.")]
        public SwimGender Gender { get; set; }

        public List<SelectListItem> SwimGenders { get; set; }

        //Swimmer Birthday-fields separate rather than datetime-easier to find agegroup
        [Required(ErrorMessage = "Select the year born.")]
        public int BirthYear { get; set; }

        public List<SelectListItem> BirthYears { get; set; }

        [Required(ErrorMessage = "Select the month born.")]
        public int BirthMonth { get; set; }

        public List<SelectListItem> BirthMonths { get; set; }

        [Required(ErrorMessage = "Select the day of the month born.")]
        public int BirthDay { get; set; }

        public List<SelectListItem> BirthDays { get; set; }


        public AddSwimmerViewModel()
        {
            SwimGenders = new List<SelectListItem>();
            
            SwimGenders.Add(new SelectListItem
            {
                Value = ((int)SwimGender.Male).ToString(),
                Text = SwimGender.Male.ToString()
            });

            SwimGenders.Add(new SelectListItem
            {
                Value = ((int)SwimGender.Female).ToString(),
                Text = SwimGender.Female.ToString()
            });

            BirthYears = new List<SelectListItem>();

            int CurrentYear = DateTime.Now.Year;
            for (int year = CurrentYear - 20; year < CurrentYear; year++)
            {
                BirthYears.Add(new SelectListItem
                {
                    Value = ((int)year).ToString(),
                    Text = year.ToString()
                });
            }

            BirthMonths = new List<SelectListItem>();

            for (int month = 1; month < 13; month++)
            {
                BirthMonths.Add(new SelectListItem
                {
                    Value = ((int)month).ToString(),
                    Text = month.ToString()
                });
            }

            BirthDays = new List<SelectListItem>();

            for (int day = 1; day < 32; day++)
            {
                BirthDays.Add(new SelectListItem
                {
                    Value = ((int)day).ToString(),
                    Text = day.ToString()
                });
            }
        }
    }
}