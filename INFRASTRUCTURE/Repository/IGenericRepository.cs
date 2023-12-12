using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.GenericReporistory
{
   
        public interface IGenericRepository<T>
        {
         
         
          T GetById(object id, string[] includeProperties = null);
        T GetById(object id);

        IEnumerable<T> Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string[] includeProperties = null,
           int skip = -1,
           int take = -1,
           bool asNoTracking = false);
        IQueryable<T> GetQueryable(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string[] includeProperties = null,
            int skip = -1,
            int take = -1,
            bool asNoTracking = false);
       
        int Count(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        void Save();
        
           T Add(T entity);
            void Update(T entity);
            void Delete(T entity);
            void Delete(object id);
        }
     
}
