using SuggeBookDAL.Dao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDAL.Repositories
{
    public interface IBookRepository
    {
        Task<List<BookDao>> GetFromAuthor(string authorId);

        Task<List<BookDao>> GetFromCategory(List<string> categories);

        Task UpdateSuggestions(string bookId, SuggestionDao suggestion);
    }
}
