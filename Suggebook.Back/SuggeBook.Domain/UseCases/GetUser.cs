using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class GetUser : IGetUser
    {
        private readonly IUserRepository _userRepository;
        public GetUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Get(string userId)
        {
            return await _userRepository.Get(userId);
        }

        public async Task<User> GetFromUsername(string username)
        {
            return await _userRepository.GetFromUsername(username);
        }
    }
}
