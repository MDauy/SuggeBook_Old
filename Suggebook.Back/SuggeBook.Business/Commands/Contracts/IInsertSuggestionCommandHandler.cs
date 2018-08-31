using SuggeBook.Dto.Models;
using SuggeBook.Framework;

namespace SuggeBook.Business.Commands.Contracts
{
    public interface IInsertSuggestionCommandHandler : ICommandHandlerAsync<SuggestionDto, bool>
    {
    }
}
