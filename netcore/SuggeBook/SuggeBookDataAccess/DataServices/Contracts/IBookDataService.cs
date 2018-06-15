using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
	public interface IBookDataService
	{
		Task<IEnumerable<Dao.Book>> GetBooks(List<ObjectId> ids);

		Task<Dao.Book> GetBook(ObjectId id);

		Task<Dao.Book> Create(Dao.Book book);

		Task<bool> Update(ObjectId id, Dao.Book book);

		Task<bool> Remove(ObjectId id);
	}
}
