using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimTimeTracker.Models
{
    public class Race
    {
        public int ID { get; set; }

        public int SwimmerID { get; set; }
        public Swimmer Swimmer { get; set; }

        public int EventID { get; set; }
        public Event Event { get; set; }

        public DateTime DateTime { get; set;}

        public TimeSpan RaceTime { get; set; }    
    }
}
