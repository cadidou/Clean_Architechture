using DOMAIN.Entities;
using INFRASTRUCTURE.GenericReporistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.UOW
{
    public interface IUnitofWorks
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
       
        void Save();
    }
}
