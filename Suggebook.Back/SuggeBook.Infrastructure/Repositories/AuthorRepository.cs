using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.Infrastructure.Exceptions;

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

        public async Task<Author> Get(string authorId)
        {
            var author = await _baseRepository.Get(a => a.Id == ObjectId.Parse(authorId));

            if (author.IsNullOrEmpty())
            {
                throw new ObjectNotFoundException("Author", authorId);
            }

            if (author.Count > 1)
            {
                throw new ObjectNotUniqueException("Author", authorId);
            }

            return (Author)author.First().ConvertToModel();
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
