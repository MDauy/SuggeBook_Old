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
            book.Author = await _authorRepository.Get(book.Author.Id);
            return book;
        }
    }
}
