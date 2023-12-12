using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DOMAIN.Entities;
namespace INFRASTRUCTURE.GenericReporistory
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private AppDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }
       

       
        
        public T Add(T entity)
        {
             
            return context.Set<T>().Add(entity).Entity;
        }
        public void Update(T entity)
        {
             
            context.Set<T>().Update(entity);
        }
        public void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public void Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

   

        public T GetById(object id, string[] includeProperties = null)
        {


            return GetQueryable(item => item.Id == id, includeProperties: includeProperties).FirstOrDefault();

        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null, int skip = -1, int take = -1, bool asNoTracking = false)
        {
            return GetQueryable(filter, orderBy, includeProperties, skip, take, asNoTracking).ToList();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null, int skip = -1, int take = -1, bool asNoTracking = false)
        { 
        
                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null && includeProperties.Length > 0)
                    query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

                query = orderBy != null ? orderBy(query) : query.OrderBy(x => x.Id);

                if (skip != -1)
                {
                    query = query.Skip(skip);
                }

                if (take != -1)
                {
                    query = query.Take(take);
                }

                if (asNoTracking) query.AsNoTracking();

                return query;
            }

        public int Count(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            return GetQueryable(filter, orderBy).Count();
        }
        public IQueryable<T> GetQueryable()
        {

            IQueryable<T> query = dbSet;

         

            return query;
        }

        public T GetById(object id)
        {
            return GetQueryable(x => x.Id == id).FirstOrDefault();
        }
    }
}
