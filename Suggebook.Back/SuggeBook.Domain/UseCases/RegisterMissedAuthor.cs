using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class RegisterMissedAuthor : IRegisterMissedAuthor
    {
        private IMissedAuthorRepository _missedAuthorRepository;

        public RegisterMissedAuthor (IMissedAuthorRepository missedAuthorRepository)
        {
            _missedAuthorRepository = missedAuthorRepository;
        }

        public async Task<MissedAuthor> Register(MissedAuthor missedAuthor)
        {
            return await _missedAuthorRepository.Register(missedAuthor);
        }
    }
}
