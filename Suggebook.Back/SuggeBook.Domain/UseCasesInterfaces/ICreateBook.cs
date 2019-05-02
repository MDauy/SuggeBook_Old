using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface ICreateBook
    {
        Task<Book> Create(Book book);
    }
}
