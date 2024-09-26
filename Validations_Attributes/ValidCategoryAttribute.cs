using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zara_GestionDVD.Validation_Attributes
{
    public class ValidCategoryAttribute : ValidationAttribute
    { 
        private readonly string[] _validCategories =
        {
            "Action", "Adolescent", "Biographie", "Cape et d'épée", "Catastrophe",
            "Chronique", "Comédie de mœurs", "Comédie d'horreur", "Comédie dramatique",
            "Comédie fantaisiste", "Comédie musicale", "Comédie policière",
            "Comédie satirique", "Comédie sentimentale", "Comédie", "Criminel",
            "Danse", "Dessins animés", "Documentaire", "Drame de guerre",
            "Drame de mœurs", "Drame d'horreur", "Drame judiciaire", "Drame musical",
            "Drame poétique", "Drame policier", "Drame psychologique",
            "Drame sentimental", "Drame social", "Drame", "Espionnage",
            "Expérimental", "Fantastique", "Film à sketches", "Film d'animation",
            "Film d'art martial", "Historique", "Horreur", "Humoristique",
            "Marionnettes", "Mélodrame", "Musical", "Road movie",
            "Romantique", "Science-fiction", "Série policière", "Série TV",
            "Spectacle d'humour", "Spectacle musical", "Suspense", "Western"
        };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string category && !_validCategories.Contains(category))
            {
                return new ValidationResult($"La catégorie '{category}' n'est pas valide. Les catégories valides sont : {string.Join(", ", _validCategories)}.");
            }
            return ValidationResult.Success;
        }
    }
}