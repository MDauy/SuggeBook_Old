using SuggeBook.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IGetHomeBooks
    {
        Task<IList<Book>> Get();
    }
}
