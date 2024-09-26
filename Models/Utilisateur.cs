using System.ComponentModel.DataAnnotations;

namespace Zara_GestionDVD.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }  

        [Required]
        public string Prenom { get; set; }

        [Required]
        [Courriel]  
        public string Courriel { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        public bool RecevoirNotifications { get; set; }
    }
}