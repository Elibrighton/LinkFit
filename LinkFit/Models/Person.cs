using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Models
{
    public abstract class Person
    {
        public int ID { get; set; }

        [Required]
        public string OwnerID { get; set; }

        [StringLength(50, ErrorMessage = "Surname cannot be longer than 50 characters.")]
        public string Surname { get; set; }

        [Display(Name = "First name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Record status")]
        public int RecordStatus { get; set; }
        
        [Display(Name = "Full name")]
        public string FullName
        {
            get
            {
                return Surname + ", " + FirstName;
            }
        }
    }
    
    public enum RecordStatus
    {
        Active = 1,
        Deleted = 0
    }
}
