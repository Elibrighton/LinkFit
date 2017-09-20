using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Models
{
    public class Athlete
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Surname cannot be longer than 50 characters.")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Enrollment date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full name")]
        public string FullName
        {
            get
            {
                return Surname + ", " + FirstName;
            }
        }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime DateOfBirth { get; set; }
        //public string EntrantCategory { get; set; } // Age grouper, professional
        //public string Gender { get; set; }

        //public ICollection<Session> Sessions { get; set; }

        [Display(Name = "Program enrollments")]
        public ICollection<ProgramEnrollment> ProgramEnrollments { get; set; }
    }
}
    