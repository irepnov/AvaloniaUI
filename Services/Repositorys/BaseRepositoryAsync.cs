using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : BaseEntity
    {
        private readonly PgApplicationContext Context;
        public BaseRepositoryAsync(PgApplicationContext context) => Context = context ?? throw new NullReferenceException("context not initialized");
        public IQueryable<T> GetAllAsQueryable() => Context.Set<T>().AsNoTracking();
        public async Task<IEnumerable<T>> GetAllAsEnumerable() => await GetAllAsQueryable().ToListAsync();
        public async Task<int> Add(T entity)
        {
            if (entity == null) throw new NullReferenceException("entity not initialized");
            await Context.Set<T>().AddAsync(entity);
            return await Context.SaveChangesAsync();
        }
        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return await Context.Set<T>().FirstOrDefaultAsync(predicate);
            else
                return await Context.Set<T>().FirstOrDefaultAsync();
        }
    }

}
