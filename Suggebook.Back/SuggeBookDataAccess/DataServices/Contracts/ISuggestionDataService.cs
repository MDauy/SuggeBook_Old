
using SuggeBookDAL.Dao;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
    public interface ISuggestionDataService
    {
        Task<SuggestionDao> Get(string id);
        Task<bool> Delete(SuggestionDao dao);
        Task Insert(SuggestionDao dao);
        Task<bool> Update(SuggestionDao dao);

    }
}
