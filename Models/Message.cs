namespace Zara_GestionDVD.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string ExpediteurId { get; set; }
        public string DestinataireId { get; set; }
        public string Sujet { get; set; }
        public string Corps { get; set; }
        public DateTime DateEnvoi { get; set; }
    }
}
