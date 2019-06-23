using SuggeBook.Domain.Exceptions;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;
using System.Threading.Tasks;

namespace SuggeBook.Infrastructure.Repositories
{
    public class MissedBookRepository : IMissedBookRepository
    {
        private readonly IBaseRepository<MissedBookDocument> _baseRepository;

        public MissedBookRepository(IBaseRepository<MissedBookDocument> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<MissedBook> Register(MissedBook missedBook)
        {
            var missedBookDocument = AutoMapper.Mapper.Map<MissedBookDocument>(missedBook);

            if (missedBookDocument != null)
            {
                missedBookDocument = await _baseRepository.Insert(missedBookDocument);

                return AutoMapper.Mapper.Map<MissedBook>(missedBookDocument);
            }
            throw new System.Exception ("Something went wrong in mapping between MissedBook and MissedBookDocument");
        }
    }
}
