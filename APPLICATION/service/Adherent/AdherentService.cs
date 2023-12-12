using APPLICATION.Services.Base;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.service.Adherent
{
    public class AdherentService : BaseService, IAdherentService
    {
        public List<Adherant> GetAdherants()
        {
            return Get<Adherant>().ToList();
        }

       
    }
}
