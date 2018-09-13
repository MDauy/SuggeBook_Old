using SuggeBookDAL.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Interactors
{
    public interface ISuggestionInteractor
    {
        Task<List<SuggestionDao>> GetFromBook(string bookId);
    }
}
