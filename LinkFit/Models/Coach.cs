using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Models
{
    public class Coach : Person
    {
        [Display(Name = "Hire date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime HireDate { get; set; }

        //[Display(Name = "Program assignment")]
        //public ICollection<ProgramAssignment> ProgramAssignments { get; set; }
    }
}
