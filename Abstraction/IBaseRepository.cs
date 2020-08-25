using CharCode.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThesisProject.Abstraction
{
    public interface IBaseRepository<T, TKey> where T : IModel<TKey>
    {
        Task<List<T>> AddRange(IEnumerable<T> entities);
        Task<List<T>> UpdateRange(IEnumerable<T> entities);
        Task DeleteRange(IEnumerable<TKey> ids);
        Task<List<T>> Get(IEnumerable<TKey> id);
    }
}
