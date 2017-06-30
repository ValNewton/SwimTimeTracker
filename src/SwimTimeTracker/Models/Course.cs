using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SwimTimeTracker.Models
{
   public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }

        public IList<Course> Courses { get; set; }

    }
}
 