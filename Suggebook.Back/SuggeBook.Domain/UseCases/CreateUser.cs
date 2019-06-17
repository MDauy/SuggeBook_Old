using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;
using SuggeBook.Domain.Exceptions;

namespace SuggeBook.Domain.UseCases
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Create(User user)
        {
            user.TestCreationValidation();
            var alreadyUsedProperties = string.Empty;
            var similarUserMail =await  _userRepository.GetSimilarMail(user.Email);
            if (similarUserMail != null)
            {
                alreadyUsedProperties += $"{user.Email} ";
            }

            var similarUserUsername = await _userRepository.GetSimilarUsername(user.Username);
            if (similarUserMail != null)
            {
                alreadyUsedProperties += $"{user.Username} ";
            }

            if (!string.IsNullOrEmpty(alreadyUsedProperties))
            {
                throw new ObjectExistingException("User", $"{alreadyUsedProperties}");

            }

            return await _userRepository.Create(user);
        }

    }
}
