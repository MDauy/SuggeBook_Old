using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Business.Commands.Contracts
{
    public interface IUpdateBookSuggestionsCommandHandler : ICommandHandlerAsync<UpdateBookSuggestionsDto, bool>
    {
    }
}
