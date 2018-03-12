using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_eventRegistration.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Student ID")]
        public String RollNo { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        [Required]
        [StringLength(50)]
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
