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
    public class SuggestionRepository : ISuggestionRepository
    {

        private readonly IBaseRepository<SuggestionDocument> _baseRepository;

        public SuggestionRepository(IBaseRepository<SuggestionDocument> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        //public async Task<List<Suggestion>> GetFromBook(string bookId)
        //{
        //    var list = await Collection.FindAsync<SuggestionDocument>(x => x.BookId == ObjectId.Parse(bookId));
        //    var suggestions = new List<Suggestion>();
        //    foreach (var suggestion in list.ToList())
        //    {
        //        suggestions.Add(suggestion.BuildSuggestionModel());
        //    }

        //    return suggestions;

        //}

        //public async Task<List<Suggestion>> GetLastFromAuthor(string authorId)
        //{
        //    var books = await _bookRepo.GetFromAuthor(authorId);
        //    var ids = books.Select(b => b.Id);

        //    var suggestions = await Collection.FindAsync<Suggestion>(s => ids.Contains(s.BookId) && s.CreationDate <= Constants.MinimalDate);

        //    return suggestions.ToList().OrderBy(s => s.CreationDate).Take(Constants.NumberOfLastSuggestionsToGetForAuthor).ToList();
        //}

        //public async Task<List<Suggestion>> GetLastFromBook(string bookId)
        //{
        //    var suggestions = await Collection.FindAsync<Suggestion>(s => s.BookId == ObjectId.Parse(bookId) && s.CreationDate <= Constants.MinimalDate);

        //    return suggestions.ToList().OrderBy(x => x.CreationDate).Take(Constants.NumberOfLastSuggestionsToGetForBook).ToList();
        //}

        //public async Task<List<Suggestion>> GetLastFromCategories(List<string> categories)
        //{
        //    var lastSuggestions = await Collection.FindAsync<Suggestion>(s => s.CreationDate <= Constants.MinimalDateForCategories);
        //    List<Suggestion> result = new List<Suggestion>();

        //    foreach (var sugge in lastSuggestions.ToList())
        //    {
        //        if (sugge.Categories.ContainsAll(categories))
        //        {
        //            result.Add(sugge);
        //        }
        //    }
        //    return result;
        //}
        public async Task<Suggestion> Insert(Suggestion suggestion)
        {
            var document = await _baseRepository.Insert(new SuggestionDocument(suggestion));
            return CustomAutoMapper.Map<SuggestionDocument, Suggestion>(document);
        }

        public async Task<Suggestion> Get(string id)
        {
            var document = await _baseRepository.Get(s => s.Id == ObjectId.Parse(id));

            if (document == null)
            {
                throw new ObjectNotFoundException("Suggestion", id);
            }
            if (document.Count > 1)
            {
                throw new ObjectNotUniqueException("Suggestion", id);
            }
            return CustomAutoMapper.Map<SuggestionDocument, Suggestion>(document.First());
        }
    }
}
