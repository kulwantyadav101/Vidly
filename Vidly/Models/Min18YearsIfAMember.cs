using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == MembershipType.Unknown
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
             return ValidationResult.Success;
            if (customer.BirthDate is null)
                return new ValidationResult("Birthdate is Required.");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            if (age > 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer should be atleast 18 years old to get on a membership.");

        }
    }
}