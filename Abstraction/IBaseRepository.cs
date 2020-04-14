using CharCode.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThesisProject.Abstraction
{
    public interface IBaseRepository<T, TKey> where T : IModel<TKey>
    {
        Task<T> Add(T entity);
        Task<List<T>> AddRange(IEnumerable<T> entities);
        Task<List<T>> Update(T entity);
        Task<List<T>> UpdateRange(IEnumerable<T> entities);
        Task Delete(TKey id);
        Task DeleteRange(IEnumerable<TKey> ids);
        Task<T> Get(TKey id);
        Task<T> Get(IEnumerable<TKey> id);
    }
}
