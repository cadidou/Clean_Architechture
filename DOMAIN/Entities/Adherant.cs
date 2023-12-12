using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    public class Adherant:BaseEntity
    {
        public string Id {  get; set; }
        public string? Nom {  get; set; }
        public string? prenom { get; set; }
        public int Numero_carte { get; set;}
        public DateTime date_inscription { get; set; }

        public int nbr_emprunt { get; set; }
        public bool sanctionne {  get; set; }
        public DateTime date_sanction{ get; set; }

        public List<ouvrage> ouvrages { get; set; }


    }
}
