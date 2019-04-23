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
            //Expression<Func<UserDocument, bool>> expression 
            
            var users = await _baseRepository.Get(x => x.UserName == username);

            if (users.Count > 1)
            {
                throw new System.Exception($"Several users wither username {username} have been found");
            }


            return null;/* AutoMapper<UserDocument, User>.Map(users.First());*/
        }
    }
}
