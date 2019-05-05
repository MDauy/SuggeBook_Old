using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.Infrastructure.Exceptions;

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
            var bookDocument = new BookDocument(book);
            bookDocument = await _baseRepository.Insert(bookDocument);
            return bookDocument.ToModel();
        }

        public async Task<Book> GetSimilar(Book book)
        {
            IList<BookDocument> existingBooks;
            if (!string.IsNullOrEmpty(book.Id))
            {
                existingBooks = await _baseRepository.Get(b =>
                   (b.Title == book.Title && b.Author.Id == new ObjectId(book.Author.Id)) ||
                   b.Id == new ObjectId(book.Id));
            }
            else
            {
                existingBooks = await _baseRepository.Get(b =>
                    b.Title == book.Title && b.Author.Id == new ObjectId(book.Author.Id));
            }

            if (existingBooks.IsNullOrEmpty())
            {
                return null;
            }

            if (existingBooks.Count > 2)
            {
                throw new ObjectNotUniqueException("Book", $"{book.Id} {book.Author.Id}");
            }

            return existingBooks.First().ToModel();
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

            return books.First().ToModel();
        }

        public async Task<List<Book>> GetFromAuthor(string authorId)
        {
            var document = await _baseRepository.Get(b => b.Author.Id == ObjectId.Parse(authorId));
            List<Book> result = new List<Book>();

            foreach (var book in document)
            {
                result.Add(book.ToModel());
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
                        results.Add(book.ToModel());
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
    }
}
