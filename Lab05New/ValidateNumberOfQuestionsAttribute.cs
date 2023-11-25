using System.ComponentModel.DataAnnotations;

namespace Lab05New
{
    public class ValidateNumberOfQuestionsAttribute : ValidationAttribute
    {

        public List<ValidationResult> validationResults = new List<ValidationResult>();

        public override bool IsValid(object? value)
        {
            var list = value as List<int>;
            if (list == null)
                return false;
            foreach (var item in list)
            {
                if (item == default || item < 1 || item > 10)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
