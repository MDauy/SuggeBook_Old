using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;

namespace SuggeBook.Business.Commands.Contracts
{
    public interface IInsertSuggestionCommandHandler : ICommandHandlerAsync<InsertSuggestionDto, SuggestionDao>
    {
    }
}
