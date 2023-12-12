using APPLICATION.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;
using DOMAIN.Entities;

namespace APPLICATION.service.Adherent
{
    public interface IAdherentService:IBaseService
    {

        List<Adherant> GetAdherants();

    }
}
