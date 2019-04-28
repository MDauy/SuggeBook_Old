using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Infrastructure.Documents;

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

        public async Task<List<Book>> GetFromAuthor(string authorId)
        {
            var document = await _baseRepository.Get(b => b.Author.Id == ObjectId.Parse(authorId));
            List<Book> result = new List<Book>();

            foreach (var book in document)
            {
                result.Add((Book) book.ConvertToModel());
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
                        results.Add((Book) book.ConvertToModel());
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
