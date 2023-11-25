using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Lab05New
{
    public class ValidateEachStringAttribute : ValidationAttribute
    {
        public List<ValidationResult> validationResults = new List<ValidationResult>();

        public override bool IsValid(object? value)
        {
            var list = value as List<string>;
            if (list == null)
                return false;
            bool isValid = true;

            foreach (var item in list)
            {
                if (item.IsNullOrEmpty()) 
                {
                    return false;
                }
            }
            return true;

        }
    }
}
