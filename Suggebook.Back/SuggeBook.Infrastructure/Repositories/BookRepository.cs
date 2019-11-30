using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BookRepository(IBaseRepository<BookDocument> baseRepository, ISuggestionRepository suggestionRepository,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _suggestionRepository = suggestionRepository;
            _mapper = mapper;
        }

        public async Task<Book> Create(Book book)
        {
            var bookDocument = _mapper.Map<BookDocument>(book);
            bookDocument = await _baseRepository.Insert(bookDocument);
            var bookResult = _mapper.Map<Book>(bookDocument);
            return bookResult;
        }

        public async Task<Book> GetSimilar(Book book)
        {
            IList<BookDocument> existingBooks = new List<BookDocument>();
            if (!string.IsNullOrEmpty(book.Id))
            {
                existingBooks = await _baseRepository.Get(b =>
                   (b.Title == book.Title && book.AuthorsIds().HasMatches<string>(b.Authors.Select(a => a.Oid.ToString()).ToList()) || b.Oid == ObjectId.Parse(book.Id)));
            }
            else
            {
                var booksWithSameTitle = await _baseRepository.Get (b => b.Title == book.Title);

                foreach (var simBook in booksWithSameTitle)
                {
                    var authorsIds = simBook.Authors.Select(a => a.Oid.ToString()).ToList();
                   if (book.AuthorsIds().HasMatches<string>(authorsIds))
                    {
                        existingBooks.Add (simBook);
                    }
                }
            }

            if (existingBooks.IsNullOrEmpty())
            {
                return null;
            }

            if (existingBooks.Count > 2)
            {                
                throw new ObjectNotUniqueException("Book", $"{book.Id} {string.Concat(book.Authors.Select(a => a.Id))}");
            }

            var bookResult = _mapper.Map<Book> (existingBooks.First());
            return bookResult;
        }

        public async Task<Book> Get(string bookId)
        {
            var books = await _baseRepository.Get(b => b.Oid == ObjectId.Parse(bookId));

            if (books.IsNullOrEmpty())
            {
                throw new ObjectNotFoundException("Book", bookId);
            }

            if (books.Count > 1)
            {
                throw new ObjectNotUniqueException("Book", bookId);
            }

            var bookModel = _mapper.Map<Book>(books.First());
            return bookModel;
        }

        public async Task<List<Book>> GetFromAuthor(string authorId)
        {
            var document = await _baseRepository.Get(b => b.Authors.Where(author => author.Oid == ObjectId.Parse(authorId)).FirstOrDefault() != null);
            List<Book> result = new List<Book>();

            foreach (var book in document)
            {
                var bookModel = _mapper.Map<Book>(book);
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
                    if (results.FirstOrDefault(b => string.Equals(b.Id, book.Oid.ToString())) == null)
                    {
                        var bookModel = _mapper.Map<BookDocument, Book>(book);
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
               var bookModel = _mapper.Map<BookDocument, Book>(document);
            }

            return booksResults;
        }

        public async Task<IList<Book>> GetBySaga(string sagaId)
        {
            var books = await _baseRepository.Get(b => b.Saga.Oid == ObjectId.Parse(sagaId));

            List<Book> result = new List<Book>();

            foreach (var book in books)
            {
                var bookModel = _mapper.Map<BookDocument, Book>(book);
            }

            return result;
        }
    }

}
