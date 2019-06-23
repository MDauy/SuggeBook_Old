using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class RegisterMissedBook : IRegisterMissedBook
    {
        private readonly IMissedBookRepository _missedBookRepository;

        public RegisterMissedBook(IMissedBookRepository missedBookRepository)
        {
            _missedBookRepository = missedBookRepository;
        }
        public async Task<MissedBook> Register(MissedBook missedBook)
        {
           return await _missedBookRepository.Register(missedBook);
        }
    }
}
