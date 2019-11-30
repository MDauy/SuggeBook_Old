using System.Threading.Tasks;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;

namespace SuggeBook.Domain.UseCases
{
    public class CreateSaga : ICreateSaga
    {
        private readonly ISagaRepository _sagaRepository;

        public CreateSaga(ISagaRepository sagaRepository)
        {
            _sagaRepository = sagaRepository;
        }

        public async Task<Saga> Create(Saga saga)
        {
            var exisingSaga = await _sagaRepository.Get(saga.Title);
            if (exisingSaga == null)
            {
                var result = await _sagaRepository.Create(saga);
                return result;
            }
            else
            {
                return exisingSaga;
            }
        }
    }
}
