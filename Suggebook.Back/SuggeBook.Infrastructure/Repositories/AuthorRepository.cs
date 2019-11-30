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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ISuggestionRepository _suggestionRepository;
        private readonly IBaseRepository<AuthorDocument> _baseRepository;
        private readonly IMapper _mapper;

        public AuthorRepository(ISuggestionRepository suggestionRepository, IBaseRepository<AuthorDocument> baseRepository,
            IMapper mapper)
        {
            _suggestionRepository = suggestionRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Author> Get(string authorId)
        {
            var author = await _baseRepository.Get(a => a.Oid == ObjectId.Parse(authorId));

            if (author.IsNullOrEmpty())
            {
                throw new ObjectNotFoundException("Author", authorId);
            }

            if (author.Count > 1)
            {
                throw new ObjectNotUniqueException("Author", authorId);
            }

            return _mapper.Map<Author>(author.First());
        }

        public async Task<Author> Create(Author author)
        {
            var authorDocument = _mapper.Map<AuthorDocument>(author);
            authorDocument = await _baseRepository.Insert(authorDocument);
            return _mapper.Map<Author>(authorDocument);
        }
        
        public async Task<Author> GetSimilar(Author author)
        {
            var authorsDocuments = await _baseRepository.Get(a =>
                string.Equals(a.Name, author.Name));
            if (authorsDocuments.IsNullOrEmpty())
            {
                return null;
            }
            if (authorsDocuments.Count > 1)
            {
                throw new ObjectNotUniqueException("Author", $"{author.Name}");
            }
            return _mapper.Map<Author>(authorsDocuments.First());
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
