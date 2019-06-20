using System.Threading.Tasks;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;

namespace SuggeBook.Infrastructure.Repositories
{
    public class MissedAuthorRepository : IMissedAuthorRepository
    {
        private IBaseRepository<MissedAuthorDocument> _baseRepository;
        public MissedAuthorRepository(IBaseRepository<MissedAuthorDocument> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<MissedAuthor> Register(MissedAuthor missedAuthor)
        {
            var missedAuthorDocument = new MissedAuthorDocument(missedAuthor);

            missedAuthorDocument = await _baseRepository.Insert(missedAuthorDocument);

            return missedAuthorDocument.ToModel();
        }
    }
}
