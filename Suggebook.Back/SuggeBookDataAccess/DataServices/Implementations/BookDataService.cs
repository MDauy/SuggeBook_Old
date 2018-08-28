using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;

namespace SuggeBookDAL.DataServices.Implementations
{
    public class BookDataService : IBookDataService
    {
        private IMongoCollection<BookDao> _booksCollection;
        private IMongoDatabase _db;

        public IMongoCollection<BookDao> BooksCollection
        {
            get
            {
                if (_booksCollection == null)
                {
                    _booksCollection = _db.GetCollection<BookDao>("Books");
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

        public async Task<Dao.BookDao> Create(Dao.BookDao book)
        {
            await BooksCollection.InsertOneAsync (book);

            return book;
        }

        public Dao.BookDao GetBook(string id)
        {
            var found = BooksCollection.Find<BookDao>(b => b.Id == ObjectId.Parse(id));

            if (found.ToList().Count > 1)
            {
                throw new Exception(string.Format("Several books with same ObjectId : {0}", id));
            }
            return found.FirstOrDefault();
        }

        public IEnumerable<Dao.BookDao> GetBooks(List<string> ids)
        {
            return BooksCollection.Find<BookDao>(b => ids.Contains(b.Id.ToString())).ToList();
        }

        public async Task<bool> Remove(ObjectId id)
        {
            var result = await BooksCollection.DeleteOneAsync<BookDao>(b => b.Id == id);

            if (result.DeletedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Update with book {0} went wrong : maybe not found or two many suggestions with same id", id));
            }
        }

        public async Task<bool> Update(ObjectId id, Dao.BookDao book)
        {
            var result = await BooksCollection.ReplaceOneAsync<BookDao>(b => b.Id == id, book);

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
