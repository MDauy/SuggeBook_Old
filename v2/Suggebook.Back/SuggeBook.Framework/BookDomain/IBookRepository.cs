using SuggeBook.Domain.BookDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDAL.Domain.BookDomain
{
    public interface IBookRepository
    {
        Task<List<Book>> GetFromAuthor(string authorId);

        Task<List<Book>> GetFromCategories(List<string> categories);
    }
}
