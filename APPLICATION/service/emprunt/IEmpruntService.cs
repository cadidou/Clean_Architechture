using APPLICATION.Services.Base;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.service.emprunt
{
    public interface IEmpruntService : IBaseService
    {
        List<DOMAIN.Entities.emprunt> GetEmprunt();


    }
}
