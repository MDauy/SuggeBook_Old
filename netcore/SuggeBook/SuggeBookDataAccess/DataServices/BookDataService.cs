using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDataAccess.Dao;

namespace SuggeBookDataAccess.DataServices
{
    public class BookDataService : IBookDataService
    {
        private IMongoCollection<Book> _usersCollection;
        private IMongoDatabase _db;

        public IMongoCollection<Book> BooksCollection
        {
            get
            {
                if (_usersCollection == null)
                {
                    _usersCollection = _db.GetCollection<Book>("Books");
                    if (_usersCollection == null)
                    {
                        _db.CreateCollection("Books");
                    }
                }
                return _usersCollection;

            }
        }

        public async Task<Dao.Book> Create(Dao.Book book)
        {
            await BooksCollection.InsertOneAsync (book);

            return book;
        }

        public async Task<Dao.Book> GetBook(ObjectId id)
        {
            var found = await BooksCollection.FindAsync<Book>(b => b.Id == id);

            if (found.ToList().Count > 1)
            {
                throw new Exception(string.Format("Several books with same ObjectId : {0}", id));
            }
            return found.FirstOrDefault();
        }

        public async Task<IEnumerable<Dao.Book>> GetBooks(List<ObjectId> ids)
        {
            return await BooksCollection.Find<Book>(b => ids.Contains(b.Id)).ToListAsync();
        }

        public async Task Remove(ObjectId id)
        {
            await BooksCollection.DeleteOneAsync<Book>(b => b.Id == id);
        }

        public async Task Update(ObjectId id, Dao.Book book)
        {
            await BooksCollection.ReplaceOneAsync<Book>(b => b.Id == id, book);
        }
    }
}
