using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBook.Domain.Model;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IGetYouMightLikeSuggestions
    {
        Task<IEnumerable<Book>> Get(string userId);
    }
}