using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimTimeTracker.Models
{
    public class Swimmer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SwimGender Gender { get; set; }
        public int BirthYear { get; set; }
        public int BirthMonth { get; set; }
        public int BirthDay { get; set; }

        public int Id { get; set; }
        
    }
}
