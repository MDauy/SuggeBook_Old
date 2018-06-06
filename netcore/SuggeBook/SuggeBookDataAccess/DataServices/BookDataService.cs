using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDataAccess.Dao;

namespace SuggeBookDataAccess.DataServices
{
	public class BookDataService : IBookDataService
	{
		private IMongoDatabase _db;
		private IMongoCollection<Dao.Book> _booksCollection;

		public BookDataService ()
		{
			_db = DataBaseAccess.Db;
			_booksCollection = _db.GetCollection<Book>("Books");
		}


		public Dao.Book Create(Dao.Book book)
		{
			_booksCollection.InsertOne(book);

			return book;
		}

		//TODO : supprimer la rechercher par ISBN --> ON METTRA LES ISBN EN CLES PRIMAIRES

		public Dao.Book GetBook(string isbn)
		{
			var found = _booksCollection.Find<Book>(b => b.ISBN == isbn);

			if (found.Count() > 1)
			{
				throw new Exception(string.Format("Several books with same ISBN : {0}", isbn));
			}

			return found.FirstOrDefault();
		}

		public Dao.Book GetBook(ObjectId id)
		{
			var found = _booksCollection.Find<Book>(b => b.Id == id);

			if (found.Count() > 1)
			{
				throw new Exception(string.Format("Several books with same ObjectId : {0}", id));
			}

			return found.FirstOrDefault();
		}	
		public IEnumerable<Dao.Book> GetBooks(List<string> isbns)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Dao.Book> GetBooks(List<ObjectId> ids)
		{
			throw new NotImplementedException();
		}

		public void Remove(ObjectId id)
		{
			throw new NotImplementedException();
		}

		public void Update(ObjectId id, Dao.Book book)
		{
			throw new NotImplementedException();
		}
	}
}
