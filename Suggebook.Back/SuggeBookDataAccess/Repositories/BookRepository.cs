using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;

namespace SuggeBookDAL.Repositories
{
    public class BookRepository : BaseRepository<BookDao>, IBookRepository
    {
        public async Task<List<BookDao>> GetFromAuthor(string authorId)
        {
            return (await Collection.FindAsync<BookDao>(x => x.Author.Id == ObjectId.Parse(authorId))).ToList();
        }

        public async Task<List<BookDao>> GetFromCategory(string category)
        {
            return (await Collection.FindAsync<BookDao>(book => book.Categories.Contains(category))).ToList();
        }
    }
}
