using ECA.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories.EF_Core
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly EcommerceAppContext ecommerceAppContext;
        public BaseRepository(EcommerceAppContext ecommerceAppContext)
        {
            this.ecommerceAppContext = ecommerceAppContext;
        }
        public virtual T Add(T entity)
        {
            this.ecommerceAppContext.Add(entity);
            this.ecommerceAppContext.SaveChanges();
            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await this.ecommerceAppContext.AddAsync(entity);
            await this.ecommerceAppContext.SaveChangesAsync();
            return entity;
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var thisObject = GetSingle(predicate);
            this.ecommerceAppContext.Set<T>().Remove(thisObject);
            this.ecommerceAppContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
           var thisObject = await GetSingleAsync(predicate);
           this.ecommerceAppContext.Set<T>().Remove(thisObject);
            await this.ecommerceAppContext.SaveChangesAsync();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return this.ecommerceAppContext.Set<T>().Where(predicate).ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.ecommerceAppContext.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return this.ecommerceAppContext.Set<T>().Where(predicate).FirstOrDefault();
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.ecommerceAppContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public virtual T Update(T entity)
        {
            this.ecommerceAppContext.Update(entity);
            this.ecommerceAppContext.SaveChanges();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            this.ecommerceAppContext.Update(entity);
            await this.ecommerceAppContext.SaveChangesAsync();
            return entity;
        }
    }
}
