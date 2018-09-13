using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;

namespace SuggeBookDAL.Repositories
{
    public class SuggestionRepository : BaseRepository<SuggestionDao>, ISuggestionRepository
    {
        public SuggestionRepository() : base()
        {

        }

        public async Task<List<SuggestionDao>> GetFromBook(string bookId)
        {
          var list = await Collection.FindAsync<SuggestionDao>(x=> x.BookId == ObjectId.Parse(bookId));
            return list.ToList();

        }
    }
}
