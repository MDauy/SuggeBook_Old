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
            var document = await _baseRepository.Get(b => b.Authors.Where(author => author.Id == ObjectId.Parse(authorId)).FirstOrDefault() != null);
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

        public async Task<IList<Book>> GetHomeBooks()
        {
            var booksDocuments = await _baseRepository.Get(_ => true);
            var booksResults = new List<Book>();

            foreach (var document in booksDocuments)
            {
                booksResults.Add(document.ToModel());
            }

            return booksResults;
        }

        public async Task<IList<Book>> GetBySaga(string sagaId)
        {
            var books = await _baseRepository.Get(b => b.Saga.Id == ObjectId.Parse(sagaId));

            List<Book> result = new List<Book>();

            foreach (var book in books)
            {
                result.Add(book.ToModel());
            }

            return result;
        }
    }

}
