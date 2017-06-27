using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwimTimeTracker.Models
{
    public enum AgeGroup
    {
        [Display(Name="10&Under")]
        TenUnder,
        [Display(Name = "11-12")]
        ElevenTwelve,
        [Display(Name = "13-14")]
        ThirteenFourteen,
        [Display(Name = "15-16")]
        FifteenSixteen,
        [Display(Name = "17-18")]
        SeventeenEighteen
    };
}
