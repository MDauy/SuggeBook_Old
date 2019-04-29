using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IGetBook
    {
        Task<Book> Get(string bookId);
    }
}
