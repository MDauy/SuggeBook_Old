using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDataAccess.Dao;

namespace SuggeBookDataAccess.DataServices
{
    public class BookDataService : IBookDataService
    {
        private IMongoCollection<Book> _booksCollection;
        private IMongoDatabase _db;

        public IMongoCollection<Book> BooksCollection
        {
            get
            {
                if (_booksCollection == null)
                {
                    _booksCollection = _db.GetCollection<Book>("Books");
                    if (_booksCollection == null)
                    {
                        _db.CreateCollection("Books");
                    }
                }
                return _booksCollection;

            }
        }

        public BookDataService ()
        {
            _db = DataBaseAccess.Db;
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

        public async Task<bool> Remove(ObjectId id)
        {
            var result = await BooksCollection.DeleteOneAsync<Book>(b => b.Id == id);

            if (result.DeletedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Update with book {0} went wrong : maybe not found or two many suggestions with same id", id));
            }
        }

        public async Task<bool> Update(ObjectId id, Dao.Book book)
        {
            var result = await BooksCollection.ReplaceOneAsync<Book>(b => b.Id == id, book);

            if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Update with book {0} went wrong : maybe not found or two many suggestions with same id", id));
            }
        }
    }
}
