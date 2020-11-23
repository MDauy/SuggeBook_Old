using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class GetAuthor : IGetAuthor
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public GetAuthor(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Author> Get(string authorId)
        {
            var author = await _authorRepository.Get(authorId);
            author.Books = await _bookRepository.GetFromAuthor(authorId);

            return author;
        }

        public async Task<List<Author>> GetByName(string name)
        {
            return await _authorRepository.GetByName(name);
        }
    }
}
