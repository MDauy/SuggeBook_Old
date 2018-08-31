using SuggeBook.Business.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;

namespace SuggeBook.Business.Implementations
{
    public class SuggestionInteractor : BaseInteractor<SuggestionDao, SuggestionDto>
    {
        public SuggestionInteractor (IBaseRepository<SuggestionDao> repository)
        {
            _repo = repository;
        }
    }
}
