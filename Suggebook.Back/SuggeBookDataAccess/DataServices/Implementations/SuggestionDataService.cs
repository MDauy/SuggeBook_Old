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
        private BaseDataService<SuggestionDao> _baseDataService;

        public SuggestionDataService ()
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

        //private IMongoCollection<SuggestionDao> _suggestionsCollection;
        //private IMongoDatabase _db;

        //public IMongoCollection<SuggestionDao> SuggestionsCollection
        //{
        //    get
        //    {
        //        if (_suggestionsCollection == null)
        //        {
        //            _suggestionsCollection = _db.GetCollection<SuggestionDao>("Suggestions");
        //            if (_suggestionsCollection == null)
        //            {
        //                _db.CreateCollection("Suggestions");
        //            }
        //        }
        //        return _suggestionsCollection;

        //    }
        //}

        //public SuggestionDataService()
        //{
        //    _db = DataBaseAccess.Db;
        //}


        //public async Task<bool> Remove(ObjectId id)
        //{
        //    var result = await SuggestionsCollection.DeleteOneAsync(s => s.Id == id);

        //    if (result.DeletedCount == 1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        throw new Exception(string.Format("Deletion with suggestion {0} went wrong : maybe not found or two many suggestions with same id", id));
        //    }
        //}


        //public async Task<BaseDao> Get(string id)
        //{
        //    var suggestion = await SuggestionsCollection.FindAsync<SuggestionDao>(s => s.Id == ObjectId.Parse(id));

        //    return suggestion.FirstOrDefault();
        //}

        //public async Task Insert(BaseDao dao)
        //{
        //    await SuggestionsCollection.InsertOneAsync((SuggestionDao)dao);

        //}

        //public BaseDao Update(BaseDao dao)
        //{
        //    var result = await SuggestionsCollection.ReplaceOneAsync(s => s.Id == dao.Id, (SuggestionDao)suggestion);

        //    if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        throw new Exception(string.Format("Update with suggestion {0} went wrong : maybe not found or two many suggestions with same id", id));
        //    }
        //}
    }
}
