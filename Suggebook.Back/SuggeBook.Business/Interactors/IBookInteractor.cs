using SuggeBookDAL.Dao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Interactors
{
    public interface IBookInteractor
    {
        Task<List<BookDao>> GetFromAuthor(string authorId);

        Task<List<BookDao>> GetFromCategory(string category);
    }
}
