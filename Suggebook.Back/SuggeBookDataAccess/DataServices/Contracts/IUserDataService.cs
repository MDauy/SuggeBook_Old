using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
    public interface IUserDataService
    {
		Task<IEnumerable<Dao.UserDao>> GetUsers(List<ObjectId> ids);

		Task<Dao.UserDao> GetUser(ObjectId id);

		Task<Dao.UserDao> Create(Dao.UserDao user);

		Task<bool> Update(ObjectId id, Dao.UserDao user);

		Task<bool> Remove(ObjectId id);
	}
}
