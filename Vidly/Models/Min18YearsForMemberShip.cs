using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 


namespace Vidly.Models
{
    public class Min18YearsForMemberShip : ValidationAttribute 
    {
       protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == 0 || customer.MemberShipTypeId == 1) return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("please enter the birthdate.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            if (age >= 18) return ValidationResult.Success;

            return new ValidationResult("Minimum age of 18 is required of the membership.");
        }
        
    }
}