using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuggeBook.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> Get(string id);
        Task<T> Insert(T dao);
        Task<bool> Delete(T document);
        Task<bool> Update(T document);
        Task<IList<T>> GetSeveral(IList<string> ids);
        Task<IList<T>> Get(Expression<Func<T, bool>> expression);
    }
}
