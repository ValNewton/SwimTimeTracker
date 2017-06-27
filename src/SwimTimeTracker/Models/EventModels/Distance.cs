using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimTimeTracker.Models
{
    public class Distance
    {
        public int ID { get; set; }
        public int Length { get; set; }

        public IList<Distance> Distances { get; set; }

    }
}
