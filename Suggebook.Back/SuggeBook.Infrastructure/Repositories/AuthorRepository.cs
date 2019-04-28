using System.Threading.Tasks;
using SuggeBook.Domain.Repositories;
using SuggeBook.Infrastructure.Documents;

namespace SuggeBook.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ISuggestionRepository _suggestionRepository;
        private readonly  IBaseRepository<AuthorDocument> _baseRepository;

        public AuthorRepository(ISuggestionRepository suggestionRepository, IBaseRepository<AuthorDocument> baseRepository)
        {
            _suggestionRepository = suggestionRepository;
            _baseRepository = baseRepository;
        }

        public async Task UpdateNbSuggestions(string authorId, string suggestionId)
        {
            var author = await _baseRepository.Get(authorId);
            var suggestion = await _suggestionRepository.Get(suggestionId);
            if (suggestion != null)
            {
                author.NbSuggestions++;
            }
            else
            {
                author.NbSuggestions--;
            }

            await _baseRepository.Update(author);
        }
    }
}
