using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services
{
    public interface IBaseRepositoryAsync<T> where T : BaseEntity
    {
        IQueryable<T> GetAllAsQueryable();
        Task<IEnumerable<T>> GetAllAsEnumerable();
        Task<int> Add(T entity);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate = null);
    }

}
