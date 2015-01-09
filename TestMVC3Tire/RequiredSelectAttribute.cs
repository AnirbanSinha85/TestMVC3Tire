using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMVC3Tire
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredSelectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(value)))
                return new ValidationResult(ErrorMessage);
            else if (!string.IsNullOrEmpty(Convert.ToString(value)))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
        
    }
}