using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.Infrastructure.Exceptions;
using static SuggeBook.Infrastructure.Documents.BookDocument;

namespace SuggeBook.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IBaseRepository<BookDocument> _baseRepository;
        private readonly ISuggestionRepository _suggestionRepository;

        public BookRepository(IBaseRepository<BookDocument> baseRepository, ISuggestionRepository suggestionRepository)
        {
            _baseRepository = baseRepository;
            _suggestionRepository = suggestionRepository;
        }

        public async Task<Book> Create(Book book)
        {
            var bookDocument = CustomAutoMapper.Map<Book, BookDocument>(book);
            bookDocument.Authors = CustomAutoMapper.MapLists<Author, BookDocument.BookAuthorDocument>(book.Authors);
            bookDocument = await _baseRepository.Insert(bookDocument);
            var bookResult =  CustomAutoMapper.Map<BookDocument, Book>(bookDocument);
            bookResult.Authors = CustomAutoMapper.MapLists<BookAuthorDocument, Author>(bookDocument.Authors);
            return bookResult;
        }

        public async Task<Book> GetSimilar(Book book)
        {
            IList<BookDocument> existingBooks;
            if (!string.IsNullOrEmpty(book.Id))
            {
                existingBooks = await _baseRepository.Get(b =>
                   (b.Title == book.Title && book.AuthorsIds.HasMatches<string>(b.Authors.Select(a => a.Id.ToString()).ToList()) || b.Id == ObjectId.Parse(book.Id)));
            }
            else
            {
                existingBooks = await _baseRepository.Get(b =>
                    b.Title == book.Title && book.AuthorsIds.HasMatches<string>(b.Authors.Select(a => a.Id.ToString()).ToList()));
            }

            if (existingBooks.IsNullOrEmpty())
            {
                return null;
            }

            if (existingBooks.Count > 2)
            {                
                throw new ObjectNotUniqueException("Book", $"{book.Id} {string.Concat(book.Authors.Select(a => a.Id))}");
            }

            var bookResult = CustomAutoMapper.Map<BookDocument,Book> (existingBooks.First());
            bookResult.Authors = CustomAutoMapper.MapLists<BookAuthorDocument, Author>(existingBooks.First().Authors);
            return bookResult;
        }

        public async Task<Book> Get(string bookId)
        {
            var books = await _baseRepository.Get(b => b.Id == ObjectId.Parse(bookId));

            if (books.IsNullOrEmpty())
            {
                throw new ObjectNotFoundException("Book", bookId);
            }

            if (books.Count > 1)
            {
                throw new ObjectNotUniqueException("Book", bookId);
            }

            var bookModel = CustomAutoMapper.Map<BookDocument, Book>(books.First());
            bookModel.Authors = CustomAutoMapper.MapLists<BookAuthorDocument, Author>(books.First().Authors);
            return bookModel;
        }

        public async Task<List<Book>> GetFromAuthor(string authorId)
        {
            var document = await _baseRepository.Get(b => b.Authors.Where(author => author.Id == ObjectId.Parse(authorId)).FirstOrDefault() != null);
            List<Book> result = new List<Book>();

            foreach (var book in document)
            {
                var bookModel = CustomAutoMapper.Map<BookDocument, Book>(book);
                bookModel.Authors = CustomAutoMapper.MapLists<BookAuthorDocument, Author>(book.Authors);
                result.Add(bookModel);
            }

            return result;
        }

        public async Task<List<Book>> GetFromCategories(List<string> categories)
        {
            var results = new List<Book>();
            foreach (var category in categories)
            {
                var books = await _baseRepository.Get(b => b.Categories.Contains(category));
                foreach (var book in books)
                {
                    if (results.FirstOrDefault(b => string.Equals(b.Id, book.Id.ToString())) == null)
                    {
                        var bookModel = CustomAutoMapper.Map<BookDocument, Book>(book);
                        bookModel.Authors = CustomAutoMapper.MapLists<BookAuthorDocument, Author>(book.Authors);
                        results.Add(bookModel);
                    }
                }
            }

            return results;
        }

        public async Task UpdateSuggestions(string bookId, string suggestionId)
        {
            var book = await _baseRepository.Get(bookId);
            var suggestion = await _suggestionRepository.Get(suggestionId);
            if (suggestion != null)
            {
                book.NbSuggestions++;
            }
            else
            {
                book.NbSuggestions--;
                await _baseRepository.Update(book);
            }
        }

        public async Task<IList<Book>> GetHomeBooks()
        {
            var booksDocuments = await _baseRepository.Get(_ => true);
            var booksResults = new List<Book>();

            foreach (var document in booksDocuments)
            {
               var bookModel = CustomAutoMapper.Map<BookDocument, Book>(document);
                bookModel.Authors = CustomAutoMapper.MapLists<BookAuthorDocument, Author>(document.Authors);
                booksResults.Add( bookModel);
            }

            return booksResults;
        }

        public async Task<IList<Book>> GetBySaga(string sagaId)
        {
            var books = await _baseRepository.Get(b => b.Saga.Id == ObjectId.Parse(sagaId));

            List<Book> result = new List<Book>();

            foreach (var book in books)
            {
                var bookModel = CustomAutoMapper.Map<BookDocument, Book>(book);
                bookModel.Authors = CustomAutoMapper.MapLists<BookAuthorDocument, Author>(book.Authors);
                result.Add(bookModel);
            }

            return result;
        }
    }

}
