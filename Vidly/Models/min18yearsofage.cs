using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidly.Models
{
    public class min18yearsofage : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId==MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.payasyougo)
            {
              
                return ValidationResult.Success;
            }

            if (customer.birthdate == null)
            {
                return new ValidationResult("Please add Birthdate");
            }

            var age = DateTime.Now.Year - customer.birthdate.Value.Year;
            return (age >= 18)
                 ? ValidationResult.Success
                 : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}