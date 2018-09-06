using SuggeBookDAL.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDAL.Repositories.Contracts
{
    public interface IBaseRepository<T> where T : BaseDao
    {
        Task<T> Get(string id);

        Task Insert(T dao);

        Task<bool> Update(T dao);

        Task<bool> Delete(T dao);

        Task<List<T>> GetSeveral(List<string> ids);

        Task<T> GetRandom();
    }
}
