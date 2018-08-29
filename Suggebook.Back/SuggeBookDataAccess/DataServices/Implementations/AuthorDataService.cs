using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Implementations
{
    public class AuthorDataService : IAuthorDataService
    {
        private IMongoCollection<AuthorDao> _authorsCollection;
        private IMongoDatabase _db;

        public IMongoCollection<AuthorDao> AuthorsCollection
        {
            get
            {
                if (_authorsCollection == null)
                {
                    _authorsCollection = _db.GetCollection<AuthorDao>("Authors");
                    if (_authorsCollection == null)
                    {
                        _db.CreateCollection("Authors");
                    }
                }
                return _authorsCollection;
            }
        }


        public async Task<AuthorDao> Create(AuthorDao author)
        {
            await AuthorsCollection.InsertOneAsync(author);

            return author;
        }

        public async Task<AuthorDao> Get(ObjectId id)
        {
            var result = await AuthorsCollection.FindAsync<AuthorDao>(a => a.Id == id);

            return result.FirstOrDefault();
        }

        public Task<bool> Remove(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ObjectId id, SuggestionDao suggestion)
        {
            throw new NotImplementedException();
        }
    }
}
