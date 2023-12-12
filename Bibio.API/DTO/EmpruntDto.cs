using DOMAIN.Entities;
using System.Text.Json.Serialization;

namespace Bibio.API.DTO
{
    public class EmpruntDto
    {
        public string Id { get; set; }

        public DateTime dateEmprunt { get; set; }
        public DateTime dateRetour { get; set; }

        
        public  string AdherantID { get; set; }
        
        public  string OuvrageID { get; set; }
    }
}
