using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class CreateBook : ICreateBook
    {
        private readonly IBookRepository _bookRepository;

        public CreateBook(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Create(Book book)
        {
            if (book.IsValid())
            {
                var similarbook = await _bookRepository.Create(book);
                if (similarbook == null)
                {
                    similarbook = await _bookRepository.Create(book);
                }
                return similarbook;
            }
            return null;
        }

        public async Task<IList<Book>> CreateSeveral(IList<Book> books)
        {
            var resultBooks = new List<Book>();

            foreach (var book in books)
            {
                resultBooks.Add(await Create(book));
            }
            return resultBooks;
        }
    }
}
