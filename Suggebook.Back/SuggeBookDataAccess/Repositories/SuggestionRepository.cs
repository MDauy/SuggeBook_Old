using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;

namespace SuggeBookDAL.Repositories
{
    public class SuggestionRepository : BaseRepository<SuggestionDao>, ISuggestionRepository
    {
        private readonly IBookRepository _bookRepo;

        public SuggestionRepository(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public async Task<List<SuggestionDao>> GetFromBook(string bookId)
        {
            var list = await Collection.FindAsync<SuggestionDao>(x => x.BookId == ObjectId.Parse(bookId));
            return list.ToList();

        }

        public async Task<List<SuggestionDao>> GetLastFromAuthor(string authorId)
        {
            var books = await _bookRepo.GetFromAuthor(authorId);
            var ids = books.Select(b => b.Id);

            var suggestions = await Collection.FindAsync<SuggestionDao>(s => ids.Contains(s.BookId) && s.CreationDate <= Constants.MINIMAL_DATE);

            return suggestions.ToList().OrderBy(s => s.CreationDate).Take(Constants.NUMBER_OF_LAST_SUGGESTIONS_TO_GET).ToList();
        }

        public async Task<List<SuggestionDao>> GetLastFromBook(string bookId)
        {
            var suggestions = await Collection.FindAsync<SuggestionDao>(s => s.BookId == ObjectId.Parse(bookId) && s.CreationDate <= Constants.MINIMAL_DATE);

            return suggestions.ToList().OrderBy(x => x.CreationDate).Take(Constants.NUMBER_OF_LAST_SUGGESTIONS_TO_GET).ToList();
        }

        public async Task<List<SuggestionDao>> GetLastFromCategories(List<string> categories)
        {
            var lastSuggestions = await Collection.FindAsync<SuggestionDao>(s => s.CreationDate <= Constants.MINIMAL_DATE_FOR_CATEGORIES);
            List<SuggestionDao> result = new List<SuggestionDao>();

            foreach (var sugge in lastSuggestions.ToList())
            {
                if (sugge.Categories.ContainsAll(categories))
                {
                    result.Add(sugge);
                }
            }
            return result;
        }
    }
}
