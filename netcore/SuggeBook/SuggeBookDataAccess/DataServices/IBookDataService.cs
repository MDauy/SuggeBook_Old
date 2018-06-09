using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDataAccess.DataServices
{
	public interface IBookDataService
	{
		Task<IEnumerable<Dao.Book>> GetBooks(List<ObjectId> ids);

		Task<Dao.Book> GetBook(ObjectId id);

		Task<Dao.Book> Create(Dao.Book book);

		Task Update(ObjectId id, Dao.Book book);

		Task Remove(ObjectId id);
	}
}
