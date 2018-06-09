using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDataAccess.Dao;
using SuggeBookDataAccess.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDataAccess.DataServices.Implementations
{
    public class AuthorDataService : IAuthorDataService
    {
        private IMongoCollection<Author> _authorsCollection;
        private IMongoDatabase _db;

        public IMongoCollection<Author> AuthorsCollection
        {
            get
            {
                if (_authorsCollection == null)
                {
                    _authorsCollection = _db.GetCollection<Author>("Authors");
                    if (_authorsCollection == null)
                    {
                        _db.CreateCollection("Authors");
                    }
                }
                return _authorsCollection;
            }
        }


        public async Task<Author> Create(Author author)
        {
            await AuthorsCollection.InsertOneAsync(author);

            return author;
        }

        public async Task<Author> Get(ObjectId id)
        {
            var result = await AuthorsCollection.FindAsync<Author>(a => a.Id == id);

            return result.FirstOrDefault();
        }

        public Task<bool> Remove(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ObjectId id, Suggestion suggestion)
        {
            throw new NotImplementedException();
        }
    }
}
