using SuggeBookDAL.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
    public interface IUserRepository
    {
		Task<IEnumerable<Dao.UserDao>> GetSeveral(List<string> ids);

		Task<Dao.UserDao> Get(string id);

		Task Insert(UserDao user);

		Task<bool> Update(UserDao user);

		Task<bool> Delete(UserDao id);
	}
}
