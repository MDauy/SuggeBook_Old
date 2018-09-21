using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;

namespace SuggeBookDAL.Repositories
{
    public class BookRepository : BaseRepository<BookDao>, IBookRepository
    {
        public async Task<List<BookDao>> GetFromAuthor(string authorId)
        {
            return (await Collection.FindAsync<BookDao>(x => x.Author.Id == ObjectId.Parse(authorId))).ToList();
        }

        public async Task<List<BookDao>> GetFromCategories(List<string> categories)
        {
            var results = new List<BookDao>();
            foreach (var category in categories)
            {
                var book = await Collection.FindAsync<BookDao>(b => b.Categories.Contains(category));
                if (book != null)
                {
                    results.Add(book.First());
                }
            }
            return results;
        }

        public async Task UpdateSuggestions(string bookId, SuggestionDao suggestion)
        {
            var book = await Get(bookId);
            var bookSuggestions = book.Suggestions;
            if (book.Suggestions.Count == Constants.NUMBER_OF_LAST_SUGGESTIONS_TO_GET_FOR_BOOK)
            {
                book.Suggestions.Remove(bookSuggestions.First());
            }
            book.Suggestions.Add(suggestion);
            var filter = Builders<BookDao>.Filter.Eq<ObjectId>(a => a.Id, ObjectId.Parse(bookId));
            await Collection.ReplaceOneAsync(filter, book);
        }
    }
}
