using INFRASTRUCTURE.GenericReporistory;
using INFRASTRUCTURE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN.Entities;

namespace APPLICATION.UOW
{
    public class UnitofWorks:IUnitofWorks
    {
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private AppDbContext context;

        private bool disposed;

        public UnitofWorks()
        {
            InitContext();
        }

        private void InitContext(AppDbContext contextParam = null)
        {
            if (context != null)
                context.Dispose();
            repositories.Clear();
            context = contextParam ?? new AppDbContext();
        }

        public static IUnitofWorks Instance()
        {
            return new UnitofWorks();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (!repositories.Keys.Contains(typeof(TEntity)))
            {
                repositories.Add(typeof(TEntity), new GenericRepository<TEntity>(context));
            }
            return repositories[typeof(TEntity)] as GenericRepository<TEntity>;
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                InitContext();
                throw new Exception("Error", exception);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

       
    }
}
