using DOMAIN;
using DOMAIN.Entities;
using System.Linq.Expressions;

namespace APPLICATION.Services.Base
{
    public interface IBaseService  
    {
        T GetById<T>(string id, string[] includeProperties = null) where T : BaseEntity;
        T GetById<T>(string id) where T : BaseEntity;
        T Add<T>(T model) where T : BaseEntity; 
        int Count<T>() where T : BaseEntity;
        void Update<T>(T model) where T : BaseEntity;
        void Delete<T>(T model) where T : BaseEntity;
        void Delete<T>(string id) where T : BaseEntity;
        
    }
}
