using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
	public interface IBookDataService
	{
		IEnumerable<Dao.BookDao> GetBooks(List<string> ids);

		Dao.BookDao GetBook(string id);

		Task Insert(Dao.BookDao book);

		Task<bool> Update(ObjectId id, Dao.BookDao book);

		Task<bool> Remove(ObjectId id);
	}
}
