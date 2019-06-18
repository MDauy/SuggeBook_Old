using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBook.Domain.Exceptions;

namespace SuggeBook.Domain.UseCases
{
    public class CreateBook : ICreateBook
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public CreateBook(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Book> Create(Book book)
        {            
            book.TestCreationValidation();
            
                var author = await _authorRepository.Get(book.Author.Id);
                if (author != null)
                {
                    book.Author = author;
                    var similarBook = await _bookRepository.GetSimilar(book);
                    if (similarBook == null)
                    {
                        // ReSharper disable once RedundantAssignment
                       return await _bookRepository.Create(book);
                    }

                    return similarBook;
                }
                throw  new InvalidObjectException("Author", book.Author.Id, "Author doesn't exist");
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
