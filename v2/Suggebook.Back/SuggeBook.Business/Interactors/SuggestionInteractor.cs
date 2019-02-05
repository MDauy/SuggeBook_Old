using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Interactors
{
    public class SuggestionInteractor : BaseInteractor<SuggestionDao>, ISuggestionInteractor
    {
        ISuggestionRepository _extraRepo;

        public SuggestionInteractor (BaseRepository<SuggestionDao> repo, ISuggestionRepository suggestionRepo)
        {
            _repo = repo;
            _extraRepo = suggestionRepo;
        }

        public async Task<List<SuggestionDao>> GetFromBook(string bookId)
        {
            return await _extraRepo.GetFromBook(bookId);    
        }

        public async Task<List<SuggestionDao>> GetLastFromAuthor(string authorId)
        {
            return await _extraRepo.GetLastFromAuthor(authorId);
        }

        public async Task<List<SuggestionDao>> GetLastFromBook(string bookId)
        {
            return await _extraRepo.GetLastFromBook(bookId);
        }

        public async Task<List<SuggestionDao>> GetLastFromCategories(List<string> categories)
        {
            return await _extraRepo.GetLastFromCategories(categories);
        }
    }
}
