using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class GetBook : IGetBook
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        public GetBook(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Book> Get(string bookId)
        {
            var book = await _bookRepository.Get(bookId);
            foreach (var author in book.Authors)
            {
                book.Authors.Add (await _authorRepository.Get(author.Id));
            }
            return book;
        }
    }
}
