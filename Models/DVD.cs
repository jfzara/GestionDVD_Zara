using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Zara_GestionDVD.Validation_Attributes;

namespace Zara_GestionDVD.Models
{
    public class DVD
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre français est requis.")]
        [StringLength(200, ErrorMessage = "Le titre français ne peut pas dépasser 200 caractères.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Le titre français ne peut contenir que des lettres, des chiffres, des espaces, des tirets.")]
        public string TitreFrancais { get; set; }

        [StringLength(200, ErrorMessage = "Le titre original ne peut pas dépasser 200 caractères.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Le titre original ne peut contenir que des lettres, des chiffres, des espaces, des tirets.")]
        public string TitreOriginal { get; set; }

        [Range(1900, 2100, ErrorMessage = "L'année de sortie doit être entre 1900 et 2100.")]
        public int AnneeSortie { get; set; }

        [Required(ErrorMessage = "La catégorie est obligatoire.")]
        [RegularExpression("^(Action|Adolescent|Biographie|Cape et d'épée|Catastrophe|Chronique|Comédie de mœurs|Comédie d'horreur|Comédie dramatique|Comédie fantaisiste|Comédie musicale|Comédie policière|Comédie satirique|Comédie sentimentale|Comédie|Criminel|Danse|Dessins animés|Documentaire|Drame de guerre|Drame de mœurs|Drame d'horreur|Drame judiciaire|Drame musical|Drame poétique|Drame policier|Drame psychologique|Drame sentimental|Drame social|Drame|Espionnage|Expérimental|Fantastique|Film à sketches|Film d'animation|Film d'art martial|Historique|Horreur|Humoristique|Marionnettes|Mélodrame|Musical|Road movie|Romantique|Science-fiction|Série policière|Série TV|Spectacle d'humour|Spectacle musical|Suspense|Western)$", ErrorMessage = "La catégorie sélectionnée n'est pas valide.")]
        public string Categorie { get; set; }

        public DateTime DerniereMiseAJour { get; set; }

        [StringLength(100, ErrorMessage = "Le nom de la personne ayant mis à jour ne peut pas dépasser 100 caractères.")]
        [RegularExpression(@"^[a-zA-Z\s\-]+$", ErrorMessage = "Le nom ne peut contenir que des lettres, des espaces et des tirets.")]
        public string DerniereMiseAJourPar { get; set; } = string.Empty; 

        [StringLength(500, ErrorMessage = "La description des suppléments ne peut pas dépasser 500 caractères.")]
        public string DescriptionSuppléments { get; set; }

        [Required(ErrorMessage = "La durée est requise.")]
        public TimeSpan Duree { get; set; }

        public bool EstDVDOriginal { get; set; }

        [StringLength(50, ErrorMessage = "Le format ne peut pas dépasser 50 caractères.")]
        public string Format { get; set; } = string.Empty; 

        [StringLength(200, ErrorMessage = "Les langues disponibles ne peuvent pas dépasser 200 caractères.")]
        public string LanguesDisponibles { get; set; } = string.Empty; 

        [Range(1, 20, ErrorMessage = "Le nombre de disques doit être entre 1 et 20.")]
        public int NombreDisques { get; set; }

        [StringLength(100, ErrorMessage = "Le nom du producteur ne peut pas dépasser 100 caractères.")]
        public string NomProducteur { get; set; } = string.Empty; 

        [StringLength(100, ErrorMessage = "Le nom du réalisateur ne peut pas dépasser 100 caractères.")]
        public string NomRealisateur { get; set; } = string.Empty; 

        [StringLength(500, ErrorMessage = "Les acteurs principaux ne peuvent pas dépasser 500 caractères.")]
        public string ActeursPrincipaux { get; set; } = string.Empty; 

        [StringLength(1000, ErrorMessage = "Le résumé du film ne peut pas dépasser 1000 caractères.")]
        public string ResumeFilm { get; set; } = string.Empty; 

        [StringLength(200, ErrorMessage = "Les sous-titres disponibles ne peuvent pas dépasser 200 caractères.")]
        public string SousTitresDisponibles { get; set; } = string.Empty; 

        [Required(ErrorMessage = "L'identifiant du propriétaire est requis.")]
        public int PropriétaireId { get; set; }

        [Required(ErrorMessage = "L'identifiant de l'emprunteur est requis.")]
        public int EmprunteurId { get; set; }

        public bool VersionEtendue { get; set; }

        public bool VisibleATous { get; set; }
    }
}