using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimTimeTracker.Models
{
    public class Event
    {
        public int ID { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }

        public int StrokeID { get; set; }
        public Stroke Stroke { get; set; }

        public int DistanceID { get; set; }
        public Distance Distance { get; set; }

    }
}
