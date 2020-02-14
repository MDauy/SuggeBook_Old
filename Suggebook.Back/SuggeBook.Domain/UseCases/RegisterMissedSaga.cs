using SuggeBook.Domain.Model;
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

        public async Task<MissedSaga> Register(MissedSaga missedSaga)
        {
            return await _missedSagaRepository. Register(missedSaga);
        }
    }
}
