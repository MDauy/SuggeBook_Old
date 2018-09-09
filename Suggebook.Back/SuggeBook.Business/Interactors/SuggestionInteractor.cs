using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Interactors
{
    public class SuggestionInteractor : BaseInteractor<SuggestionDao>
    {
        public SuggestionInteractor (BaseRepository<SuggestionDao> repo)
        {
            _repo = repo;
        }      
    }
}
