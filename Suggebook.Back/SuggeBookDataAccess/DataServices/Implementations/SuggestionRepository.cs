using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;

namespace SuggeBookDAL.DataServices.Implementations
{
    public class SuggestionRepository : ISuggestionRepository
    {
        private readonly IBaseRepository<SuggestionDao> _repo;

        public SuggestionRepository (IBaseRepository<SuggestionDao> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Delete(SuggestionDao dao)
        {
            return await _repo.Delete(dao);
        }

        public async Task<SuggestionDao> Get(string id)
        {
            return await _repo.Get(id);
        }

        public async Task<List<SuggestionDao>> GetSeveral(List<string> ids)
        {
            return await _repo.GetSeveral(ids);

        }

        public async Task Insert(SuggestionDao dao)
        {
            await _repo.Delete(dao);
        }

        public async Task<bool> Update(SuggestionDao dao)
        {
            return await _repo.Update(dao);
        }
    }
}
