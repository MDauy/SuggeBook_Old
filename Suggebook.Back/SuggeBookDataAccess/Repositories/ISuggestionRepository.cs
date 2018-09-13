using SuggeBookDAL.Dao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDAL.Repositories
{
    public interface ISuggestionRepository
    {
        Task<List<SuggestionDao>> GetFromBook(string bookId);
    }
}
