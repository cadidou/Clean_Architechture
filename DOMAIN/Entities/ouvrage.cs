using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    public class ouvrage:BaseEntity
    {
        //definiton des attribut
        
        public string Id{  get; set; }
        public string? titre { get; set; }
        public string? auteur { get; set; }
        public string? domain { get; set; }

        public int  Nbr {  get; set; }
        public bool consultable { get; set; }

        //properites de navigation
        public List<Adherant> adherants { get; set; } 
    }
}
