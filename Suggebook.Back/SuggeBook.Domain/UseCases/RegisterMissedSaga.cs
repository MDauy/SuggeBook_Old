using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class RegisterMissedSaga : IRegisterMissedSaga
    {
        private IMissedSagaRepository _missedSagaRepository;

        public RegisterMissedSaga (IMissedSagaRepository missedSagaRepository)
        {
            _missedSagaRepository= missedSagaRepository;
        }

        public async Task Register(string title, string message)
        {
            await _missedSagaRepository. Register(title, message);
        }
    }
}
