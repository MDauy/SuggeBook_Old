using SuggeBook.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface ICreateBook
    {
        Task<Book> Create(Book book);

        Task<IList<Book>> CreateSeveral(IList<Book> books);
    }
}