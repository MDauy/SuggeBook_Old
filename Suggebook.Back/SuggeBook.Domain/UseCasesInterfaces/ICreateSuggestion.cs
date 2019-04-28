using System.Threading.Tasks;
using SuggeBook.Domain.Model;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface ICreateSuggestion
    {
        Task<Suggestion> Create(Suggestion suggestion);
    }
}
