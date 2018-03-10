using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_eventRegistration.Models
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Student ID  cannot be longer than 15 characters.")]
        [Display(Name = "Student ID")]
        public String RollNo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="Name cannot be longer than 50 characters")]
        [Display(Name = "Your Name")]
        public String Name { get; set; }

        [Required]
        [StringLength(50 , ErrorMessage = "Fathers Name cannot be longer than 50 characters")]
        [Display(Name ="Fathers Name")]
        public String FathersName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Education")]
        public string EduQualification { get; set; }
       
    }
}
