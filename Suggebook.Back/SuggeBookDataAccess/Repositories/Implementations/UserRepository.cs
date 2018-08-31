using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;

namespace SuggeBookDAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
	{
        private readonly IBaseRepository<UserDao> _repo;

        public UserRepository (IBaseRepository<UserDao> repo)
        {

        }

        public async Task<bool> Delete(UserDao dao)
        {
            return await _repo.Delete(dao);
        }

        public async Task<UserDao> Get(string id)
        {
            return await _repo.Get(id);
        }

        public async Task<IEnumerable<UserDao>> GetSeveral(List<string> ids)
        {
            return await _repo.GetSeveral(ids);
        }

        public async Task Insert(UserDao user)
        {
            await _repo.Insert(user);
        }

        public async Task<bool> Update(UserDao user)
        {
            return await _repo.Update(user);
        }
    }
}
