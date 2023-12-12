using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    public class emprunt:BaseEntity
    {

        public string Id { get; set; }

        public DateTime dateEmprunt { get; set; }
        public DateTime dateRetour {  get; set; }


       
        public string AdherantID { get; set; }
       
        public string OuvrageID { get; set; }


    }
}
