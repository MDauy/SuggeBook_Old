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
            if (book.IsValid())
            {
                var bookDocument = CustomAutoMapper.Map<Book, BookDocument>(book);
                if (bookDocument != null)
                {
                    bookDocument = await _baseRepository.Insert(bookDocument);
                    return (Book)bookDocument.ConvertToModel();
                }
            }
            return null;
        }

        public async Task<List<Book>> GetSimilar(Book book)
        {
            var existingBook = await _baseRepository.Get(b => b.Id == ObjectId.Parse(book.Id) || (b.Title == book.Title && b.Author.Id == ObjectId.Parse(book.Author.Id)));

            if (existingBook.IsNullOrEmpty())
            {
                return null;
            }
            var books = new List<Book>();
            foreach (var b in existingBook)
            {
                books.Add(CustomAutoMapper.Map<BookDocument, Book>(b));
            }
            return books;
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

            return (Book)books.First().ConvertToModel();
        }

        public async Task<List<Book>> GetFromAuthor(string authorId)
        {
            var document = await _baseRepository.Get(b => b.Author.Id == ObjectId.Parse(authorId));
            List<Book> result = new List<Book>();

            foreach (var book in document)
            {
                result.Add((Book)book.ConvertToModel());
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
                        results.Add((Book)book.ConvertToModel());
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
