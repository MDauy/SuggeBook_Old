using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDataAccess.DataServices
{
	public interface IBookDataService
	{
		Task<IEnumerable<Dao.Book>> GetBooks(List<ObjectId> ids);

		Dao.Book GetBook(ObjectId id);

		Dao.Book Create(Dao.Book book);

		void Update(ObjectId id, Dao.Book book);

		void Remove(ObjectId id);
	}
}
