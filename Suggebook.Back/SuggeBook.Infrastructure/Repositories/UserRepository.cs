using System.Threading.Tasks;
using MongoDB.Driver;
using System.Linq;
using SuggeBook.Infrastructure;
using SuggeBookDAL.Domain.UserDomain;
using SuggeBookDAL.Persistence.Documents;
using SuggeBook.Domain.UserDomain;
using System;
using System.Collections.Generic;

namespace SuggeBookDAL.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository (IBaseRepository<UserDocument> baseRepo)
        {
            _baseRepository = baseRepo;
        }

        private IBaseRepository<UserDocument> _baseRepository;

        public async Task<User> GetFromUsername(string username)
        {
            Func<List<User>, List<UserDocument>> func = list => list.FirstOrDefault(u => u.UserName == username)
            var users = await _baseRepository.Get();
            var usersList = users.ToList();
            if (usersList.Count > 1)
            {
                throw new System.Exception($"Several users wither username {username} have been found");
            }

            return usersList.FirstOrDefault();
        }
    }
}
