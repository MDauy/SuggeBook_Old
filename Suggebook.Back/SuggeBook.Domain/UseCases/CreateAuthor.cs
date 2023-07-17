using System.Threading.Tasks;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;

namespace SuggeBook.Domain.UseCases
{
    public class CreateAuthor : ICreateAuthor
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthor(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Create(Author author)
        {
            author.IsValid();

            var similarAuthor = await _authorRepository.GetSimilar(author);
            if (similarAuthor == null)
            {
                return await _authorRepository.Create(author);
            }

            return similarAuthor;
        }
    }
}