//using System.Linq;
//using System.Threading.Tasks;
//using MongoDB.Bson;
//using SuggeBookDAL.Framework;
//using MongoDB.Driver;
//using SuggeBookDAL.Persistence.Documents;
//using SuggeBookDAL.Repositories;

//namespace SuggeBookDAL.Infrastructure.Repositories
//{
//    public class AuthorRepository : BaseRepository<AuthorDocument>
//    {
//        public async Task UpdateAuthorSuggestions(string authorId, SuggestionDao sugge)
//        {
//            var author = await Get(authorId);
//            var suggestions = author.Suggestions;
//            if (author.Suggestions != null && author.Suggestions.Count == Constants.NUMBER_OF_LAST_SUGGESTIONS_TO_GET_FOR_AUTHOR)
//            {
//                author.Suggestions.Remove(suggestions.First());
//            }
//            author.Suggestions.Add(sugge);
//            author.NbSuggestions++;
//            var filter = Builders<AuthorDao>.Filter.Eq<ObjectId>(a => a.Id, ObjectId.Parse(authorId));
//            await Collection.ReplaceOneAsync(filter, author);
//        }
//    }
//}
