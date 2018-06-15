using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
    public interface IUserDataService
    {
		Task<IEnumerable<Dao.User>> GetUsers(List<ObjectId> ids);

		Task<Dao.User> GetUser(ObjectId id);

		Task<Dao.User> Create(Dao.User user);

		Task<bool> Update(ObjectId id, Dao.User user);

		Task<bool> Remove(ObjectId id);
	}
}
