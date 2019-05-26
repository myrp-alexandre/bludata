using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_bludata.domain.domain.interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> SaveAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        T[] SaveRange(T[] entity);
        T[] UpdateRange(T[] entity);
        //Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
