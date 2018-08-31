using SuggeBookDAL.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDao>> GetSeveral(List<string> ids);

        Task<BookDao> Get(string id);

        Task Insert(BookDao book);

        Task<bool> Update(BookDao book);

        Task<bool> Delete(BookDao id);
    }
}
