using SuggeBook.Dto.Models;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Contracts
{
    public interface ISuggestionService
    {
        Task Insert(InsertSuggestionDto dto);
    }
}
