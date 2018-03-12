using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_eventRegistration.Models
{
    public class AgeCalculate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime given = (DateTime)value;
            return DateTime.Now.Year - given.Year > 18;
        }
        
    }
}