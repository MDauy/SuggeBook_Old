using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;

namespace SuggeBookDAL.DataServices.Implementations
{
    public class SuggestionDataService : ISuggestionDataService
    {
        

        public SuggestionDataService (IBaseDataService<SuggestionDao> baseDataService)
        {
            _baseDataService = new BaseDataService<SuggestionDao>("Suggestion");
        }

        public async Task<bool> Delete(SuggestionDao dao)
        {
            return await _baseDataService.Delete(dao);
        }

        public async Task<SuggestionDao> Get(string id)
        {
            return await _baseDataService.Get(id);
        }

        public async Task Insert(SuggestionDao dao)
        {
            await _baseDataService.Delete(dao);
        }

        public async Task<bool> Update(SuggestionDao dao)
        {
            return await _baseDataService.Update(dao);
        }
    }
}
