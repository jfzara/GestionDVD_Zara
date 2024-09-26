namespace Zara_GestionDVD.Models
{
    public class Historique
    {
        public int Id { get; set; }
        public int DVDId { get; set; }
        public string UtilisateurId { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
    }
}
