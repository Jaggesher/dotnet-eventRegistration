using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_eventRegistration.Models
{
    public class AgeCalculate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value , ValidationContext validationContext)
        {
            DateTime given = (DateTime)value;
            bool flag = DateTime.Now.Year - given.Year > 18;

            if(!flag)
            {
                return new ValidationResult("Your age must be at least 18 years.");
            }

            return ValidationResult.Success;
        }
        
    }
}