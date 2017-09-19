using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Models
{
    public class TrainingProgram
    {
        public int ID { get; set; }
        public string Title { get; set; }
        //public decimal Cost { get; set; }
        //public string DeliveryMethod { get; set; } // online, group or one on one
        //public string Sport { get; set; } // triathlon, running, swimming

        public ICollection<ProgramEnrollment> ProgramEnrollments { get; set; }
    }
}
