using MongoDB.Bson;
using System.Collections.Generic;

namespace SuggeBookDataAccess.DataServices
{
	public interface IBookDataService
	{
		IEnumerable<Dao.Book> GetBooks(List<string> isbns);

		IEnumerable<Dao.Book> GetBooks(List<ObjectId> ids);

		Dao.Book GetBook(string isbn);

		Dao.Book GetBook(ObjectId id);

		Dao.Book Create(Dao.Book book);

		void Update(ObjectId id, Dao.Book book);

		void Remove(ObjectId id);
	}
}
