
using SuggeBookDAL.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
    public interface ISuggestionRepository
    {
        Task<SuggestionDao> Get(string id);
        Task<bool> Delete(SuggestionDao dao);
        Task Insert(SuggestionDao dao);
        Task<bool> Update(SuggestionDao dao);
        Task<List<SuggestionDao>> GetSeveral(List<string> ids);

    }
}
