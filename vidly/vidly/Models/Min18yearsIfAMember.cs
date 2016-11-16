using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Min18yearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Aniversario é obrigatório.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("A idade do cliente deve ser no minimo 18 anos");
        }
    }
}