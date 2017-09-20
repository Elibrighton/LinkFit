using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Models
{
    public class TrainingProgram
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        //public string DeliveryMethod { get; set; } // online, group or one on one
        //public string Sport { get; set; } // triathlon, running, swimming

        [Display(Name = "Program enrollments")]
        public ICollection<ProgramEnrollment> ProgramEnrollments { get; set; }
    }
}
