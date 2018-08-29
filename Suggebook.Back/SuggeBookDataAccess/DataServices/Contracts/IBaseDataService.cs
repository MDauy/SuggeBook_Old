using SuggeBookDAL.Dao;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
    public interface IBaseDataService<T> where T : BaseDao
    {
        Task<T> Get(string id);

        Task Insert(T dao);

        Task<bool> Update(T dao);

        Task<bool> Delete(T dao);
    }
}
