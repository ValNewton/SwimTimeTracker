using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SwimTimeTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

    
namespace SwimTimeTracker.ViewModels
{
    public class AddDistanceViewModel
    {
        [Required]
        public int Length { get; set; }

        public AddDistanceViewModel() { }
    }
}
