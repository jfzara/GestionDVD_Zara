using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zara_GestionDVD.Models
{
    public class CourrielAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Le courriel est requis.");
            }

            var email = value.ToString();
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!regex.IsMatch(email))
            {
                return new ValidationResult("Le format du courriel est invalide.");
            }

            return ValidationResult.Success;
        }
    }
}