using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Models
{
    public class ProgramEnrollment
    {
        public int AthleteID { get; set; }
        public int TrainingProgramID { get; set; }

        public Athlete Athlete { get; set; }

        [Display(Name = "Training program")]
        public TrainingProgram TrainingProgram { get; set; }
    }
}
