using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwimTimeTracker.Models;
using System.ComponentModel.DataAnnotations;        

namespace SwimTimeTracker.ViewModels
{
    public class AddCourseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abbr { get; set; }
}
}
