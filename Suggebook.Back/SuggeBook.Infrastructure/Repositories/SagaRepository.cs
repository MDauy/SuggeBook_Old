using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.Infrastructure.Exceptions;

namespace SuggeBook.Infrastructure.Repositories
{
    public class SagaRepository : ISagaRepository
    {
        private readonly IBaseRepository<SagaDocument> _baseRepository;
        private readonly IMapper _mapper;

        public SagaRepository(IBaseRepository<SagaDocument> baseRepository, IBaseRepository<BookDocument> bookRepository,
        IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<Saga> Get(string title)
        {
            var saga = await _baseRepository.Get(s => s.Title == title);

            if (!saga.IsNullOrEmpty())
            {
                throw new ObjectNotFoundException("Saga", title);
            }

            if (saga.Count > 1)
            {
                throw new ObjectNotUniqueException("Saga", title);
            }

            return _mapper.Map<Saga>(saga.First());
        }

        public async Task<Saga> GetById(string id)
        {
            var saga = await _baseRepository.Get(s => s.Oid == ObjectId.Parse(id));

            if (!saga.IsNullOrEmpty())
            {
                return _mapper.Map<Saga>(saga.First());
            }
            return null;
        }

        public async Task<Saga> Create(Saga saga)
        {
            var sagaDocument = _mapper.Map<Saga, SagaDocument>(saga);
            sagaDocument = await _baseRepository.Insert(sagaDocument);
            return _mapper.Map<Saga>(sagaDocument);
        }
    }
}
