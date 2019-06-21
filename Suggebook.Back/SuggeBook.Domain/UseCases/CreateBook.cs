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
            var authors = new List<Author>();
            var authorsId = string.Empty;
            foreach (var author in book.Authors)
            {
                var authorTmp = await _authorRepository.Get(author.Id);
                if (authorTmp != null)
                {
                    authors.Add(authorTmp);
                }
                else
                {
                    
                   authorsId += author.Id;

                }
            }
            if (authors.Count == book.Authors.Count)
            {
                book.Authors = authors;
                var similarBook = await _bookRepository.GetSimilar(book);
                if (similarBook == null)
                {
                    // ReSharper disable once RedundantAssignment
                    return await _bookRepository.Create(book);
                }

                return similarBook;
            }
            else
            {
                throw  new InvalidObjectException("Author", authorsId, "Author doesn't exist");

            }

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
