using System.Linq;
using System.Threading.Tasks;
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
        private readonly IBaseRepository<BookDocument> _bookRepository;
        public SagaRepository(IBaseRepository<SagaDocument> baseRepository, IBaseRepository<BookDocument> bookRepository)
        {
            _baseRepository = baseRepository;
            _bookRepository = bookRepository;
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

            return CustomAutoMapper.Map<Saga>(saga.First());
        }

        public async Task<Saga> Create(Saga saga)
        {
            var sagaDocument = CustomAutoMapper.Map<SagaDocument>(saga);
            sagaDocument = await _baseRepository.Insert(sagaDocument);
            return CustomAutoMapper.Map<Saga>(sagaDocument);
        }
    }
}
