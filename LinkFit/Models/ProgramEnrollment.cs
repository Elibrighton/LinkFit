using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Models
{
    public class ProgramEnrollment
    {
        public int ID { get; set; }
        public int AthleteID { get; set; }
        public int TrainingProgramID { get; set; }

        public Athlete Athlete { get; set; }
        public TrainingProgram TrainingProgram { get; set; }
    }
}
