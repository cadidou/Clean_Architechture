using APPLICATION.Services.Base;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.service.Ouvrages
{
    public interface IouvrageService:IBaseService
    {
        List<ouvrage> GetAllouvrages();
    }
}
