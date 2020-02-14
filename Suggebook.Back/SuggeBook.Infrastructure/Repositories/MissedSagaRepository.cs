using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Infrastructure.Repositories
{
    public class MissedSagaRepository : IMissedSagaRepository
    {

        private readonly IBaseRepository<MissedSagaDocument> _baseRepository;
        private readonly IMapper _mapper;

        public MissedSagaRepository (IBaseRepository<MissedSagaDocument> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<MissedSaga> Register(MissedSaga missedSaga)
        {
            var missedSagaDocument = _mapper.Map<MissedSagaDocument> (missedSaga);
            if (missedSagaDocument != null)
            {
                missedSagaDocument = await _baseRepository.Insert(missedSagaDocument);

                return _mapper.Map<MissedSaga> (missedSagaDocument);
            }
            throw new Exception("Something went wrong in mapping between MissedSaga and MissedSagaDocument");
        }
    }
}
