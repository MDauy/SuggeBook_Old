using System.Threading.Tasks;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;

namespace SuggeBook.Domain.UseCases
{
    public class ConnectUser : IConnectUser
    {
        private readonly IUserRepository _userRepository;

        public ConnectUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Connect(string usernameOrEmail, string password)
        {
            return await _userRepository.Connect(usernameOrEmail, password);
        }
    }
}
