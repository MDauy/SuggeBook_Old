using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class GetSaga : IGetSaga
    {
        private ISagaRepository _sagaRepository;

        public GetSaga(ISagaRepository sagaRepository)
        {
            _sagaRepository = sagaRepository;
        }
        async Task<Saga> IGetSaga.GetSaga(string sagaId)
        {
            return await _sagaRepository.GetById(sagaId);
        }

    }
}
