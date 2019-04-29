using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class GetAuthor : IGetAuthor
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthor(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> IGetAuthor.GetAuthor(string authorId)
        {
            var author = await _authorRepository.
        }
    }
}
