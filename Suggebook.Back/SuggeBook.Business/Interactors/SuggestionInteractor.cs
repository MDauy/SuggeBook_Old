using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Interactors
{
    public class SuggestionInteractor : BaseInteractor<SuggestionDao>, ISuggestionInteractor
    {
        ISuggestionRepository _suggestionRepo;

        public SuggestionInteractor (BaseRepository<SuggestionDao> repo, ISuggestionRepository suggestionRepo)
        {
            _repo = repo;
            _suggestionRepo = suggestionRepo;
        }

        public async Task<List<SuggestionDao>> GetFromBook(string bookId)
        {
            return await _suggestionRepo.GetFromBook(bookId);    
        }
    }
}
