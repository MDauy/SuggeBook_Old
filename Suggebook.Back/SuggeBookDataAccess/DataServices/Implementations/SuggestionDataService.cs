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
        private IMongoCollection<Suggestion> _suggestionsCollection;
        private IMongoDatabase _db;

        public IMongoCollection<Suggestion> SuggestionsCollection
        {
            get
            {
                if (_suggestionsCollection == null)
                {
                    _suggestionsCollection = _db.GetCollection<Suggestion>("Suggestions");
                    if (_suggestionsCollection == null)
                    {
                        _db.CreateCollection("Suggestions");
                    }
                }
                return _suggestionsCollection;

            }
        }

        public SuggestionDataService()
        {
            _db = DataBaseAccess.Db;
        }

        public async Task<Suggestion> Create(Suggestion suggestion)
        {
            await SuggestionsCollection.InsertOneAsync(suggestion);

            return suggestion;
        }

        public async Task<Suggestion> Get(ObjectId id)
        {
            var suggestion = await SuggestionsCollection.FindAsync<Suggestion>(s => s.Id == id);

            return suggestion.FirstOrDefault();
        }

        public async Task<bool> Remove(ObjectId id)
        {
            var result = await SuggestionsCollection.DeleteOneAsync(s => s.Id == id);

            if (result.DeletedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Deletion with suggestion {0} went wrong : maybe not found or two many suggestions with same id", id));
            }
        }

        public async Task<bool> Update(ObjectId id, Suggestion suggestion)
        {
            var result = await SuggestionsCollection.ReplaceOneAsync(s => s.Id == id, suggestion);

            if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Update with suggestion {0} went wrong : maybe not found or two many suggestions with same id", id));
            }
        }
    }
}
