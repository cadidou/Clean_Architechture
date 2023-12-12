using APPLICATION.UOW;
using DOMAIN;
using DOMAIN.Entities;
using INFRASTRUCTURE;
using INFRASTRUCTURE.GenericReporistory;
using System.Linq.Expressions;

namespace APPLICATION.Services.Base
{
    public class BaseService : IBaseService
    {
        internal IUnitofWorks unitofWork;
        public BaseService()
        {
            this.unitofWork = new UnitofWorks();
        }

        public BaseService(IUnitofWorks unitOfWork)
        {
            this.unitofWork= unitOfWork;
        }

        
        

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> filter = null, string[] includeProperties = null) where TEntity : BaseEntity
        {
            unitofWork.GetRepository<TEntity>();
            unitofWork.Save();
        }

        public void Save()
        {
            unitofWork.Save();
        }

        public T Add<T>(T model) where T : BaseEntity
        {
            var entity = unitofWork.GetRepository<T>().Add(model);
            Save();
            return entity;
        }

       

        public void Update<TEntity>(TEntity model) where TEntity : BaseEntity
        {
            unitofWork.GetRepository<TEntity>().Update(model);
            unitofWork.Save();
        }

       

       

        

        public virtual void Delete<T>(T model) where T : BaseEntity
        {
            unitofWork.GetRepository<T>().Delete(model);
            unitofWork.Save();
        }

      

        
        public  int Count<T>() where T : BaseEntity
        {
           return unitofWork.GetRepository<T>().Count();
        }

        public void Delete<T>(string id) where T : BaseEntity
        {
            Delete(GetById<T>(id));
        }

        public T GetById<T>(string id, string[] includeProperties = null) where T : BaseEntity
        {
            return unitofWork.GetRepository<T>().GetById(id, includeProperties);
        }
        public T GetById<T>(string id) where T : BaseEntity
        {
            return unitofWork.GetRepository<T>().GetById(id);
            
        }
        public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, string[] includeProperties = null, bool asNoTracking = false) where TEntity : BaseEntity
        {
            return unitofWork.GetRepository<TEntity>().GetQueryable(filter, includeProperties: includeProperties, asNoTracking: asNoTracking);
        }
    }

}
