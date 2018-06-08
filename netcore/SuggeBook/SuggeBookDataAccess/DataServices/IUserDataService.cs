using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDataAccess.DataServices
{
    public interface IUserDataService
    {
		Task<IEnumerable<Dao.User>> GetUsers(List<ObjectId> ids);

		Dao.User GetUser(ObjectId id);

		Dao.User Create(Dao.User user);

		void Update(ObjectId id, Dao.User user);

		void Remove(ObjectId id);
	}
}
