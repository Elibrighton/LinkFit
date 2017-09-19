using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Models
{
    public class Athlete
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public string EntrantCategory { get; set; } // Age grouper, professional
        public string Gender { get; set; }

        //public ICollection<Session> Sessions { get; set; }
        public ICollection<ProgramEnrollment> ProgramEnrollments { get; set; }
    }
}
    