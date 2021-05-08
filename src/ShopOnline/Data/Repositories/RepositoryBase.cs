using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        // Triển khai Generic được định nghĩa trong IRepository
        private ShopContext context;

        private DbSet<T> dbSet;

        public IDbFactory DbFactory { get; private set; }

        public ShopContext DbContext
        {
            get { return context ?? (context = DbFactory.Init()); }
        }

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            this.dbSet = DbContext.Set<T>();
        }

        public virtual T add(T model)
        {
            try
            {
                return dbSet.Add(model);
            }catch
            {
                throw;
            }
        }

        public virtual bool update(T model)
        {
            dbSet.Attach(model);
            context.Entry(model).State = EntityState.Modified;
            return context.SaveChanges()>0;
        }

        public virtual T delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public virtual ICollection<T> findAll()
        {
            return dbSet.ToList();
        }

        public virtual T findById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T delete(T model)
        {
            return dbSet.Remove(model);
        }

        public virtual ICollection<T> findAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = context.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable().ToList();
            }

            return context.Set<T>().AsQueryable().ToList();
        }
        public virtual ICollection<T> findByCondition(Expression<Func<T,bool>> expression,string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = context.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return  query.Where<T>(expression).ToList();
            }
            return context.Set<T>().Where<T>(expression).ToList();
        }
    }
}