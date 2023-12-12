using APPLICATION.Services.Base;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.service.Ouvrages
{
    public class OuvrageService : BaseService, IouvrageService
    {
        public List<ouvrage> GetAllouvrages()
        {
            return Get<ouvrage>().ToList();
        }
    }
}
