using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;

namespace SuggeBookDAL.Repositories.Implementations
{
    public class SuggestionRepository : ISuggestionRepository
    {
        private readonly IBaseRepository<SuggestionDao> _baseRepo;

        public SuggestionRepository (IBaseRepository<SuggestionDao> repo)
        {
            _baseRepo = repo;
        }

        public async Task<bool> Delete(SuggestionDao dao)
        {
            return await _baseRepo.Delete(dao);
        }

        public async Task<SuggestionDao> Get(string id)
        {
            return await _baseRepo.Get(id);
        }

        public async Task<List<SuggestionDao>> GetSeveral(List<string> ids)
        {
            return await _baseRepo.GetSeveral(ids);

        }

        public async Task Insert(SuggestionDao dao)
        {
            await _baseRepo.Insert(dao);
        }

        public async Task<bool> Update(SuggestionDao dao)
        {
            return await _baseRepo.Update(dao);
        }
    }
}
