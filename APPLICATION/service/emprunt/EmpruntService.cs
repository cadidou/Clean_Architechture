using APPLICATION.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.service.emprunt
{
    public class EmpruntService:BaseService,IEmpruntService
    {
        public EmpruntService() { }

        public List<DOMAIN.Entities.emprunt> GetEmprunt()
        {
            return Get<DOMAIN.Entities.emprunt>().ToList();
        }

       
    }
}
