using DOMAIN.Entities;

namespace Bibio.API.DTO
{
    public class AdherantDto
    {
        public string Id {  get; set; }
        public string? Nom { get; set; }
        public string? prenom { get; set; }
        public int Numero_carte { get; set; }
        public DateTime date_inscription { get; set; }

        public int nbr_emprunt { get; set; }
        public bool sanctionne { get; set; }
        public DateTime date_sanction { get; set; }

        
    }
}
