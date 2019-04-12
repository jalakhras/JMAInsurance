using System;
using System.ComponentModel.DataAnnotations;

namespace JMAInsurance.Models.Infrastructure.CustomValidator
{
    public class BirthdateValidator : ValidationAttribute
    {
        public BirthdateValidator()
        {
            ErrorMessage = "Please enter a valid birth date. You must be 18 or older to apply.";
        }
        public override bool IsValid(object value)
        {
            DateTime enteredDate;
            if (DateTime.TryParse(value.ToString(), out enteredDate))
            {
                if (enteredDate > DateTime.Now.AddYears(-18))
                    return false;
                 return true;
                

            }
            return false;
          
        }

    }
}
