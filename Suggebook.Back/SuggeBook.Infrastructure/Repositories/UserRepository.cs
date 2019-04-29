using System.Linq;
using System.Threading.Tasks;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.Infrastructure.Exceptions;
using SuggeBook.Framework;

namespace SuggeBook.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository (IBaseRepository<UserDocument> baseRepo)
        {
            _baseRepository = baseRepo;
        }

        private readonly IBaseRepository<UserDocument> _baseRepository;

        public async Task<User> Create(User user)
        {
                var userDocument = await _baseRepository.Insert(new UserDocument(user));
                return (User)userDocument.ConvertToModel(); 
        }

        public async Task<User> GetFromUsername(string username)
        {
            var users = await _baseRepository.Get(x => x.UserName == username);

            if (users.Count > 1)
            {
                throw new ObjectNotUniqueException("User", username);
            }
            return CustomAutoMapper.Map<UserDocument, User>(users.First());
        }
    }
}
