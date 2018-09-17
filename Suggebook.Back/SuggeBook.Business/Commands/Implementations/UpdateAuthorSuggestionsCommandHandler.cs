using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class UpdateAuthorSuggestionsCommandHandler : IUpdateAuthorSuggestionsCommandaHandler
    {
        public Task<bool> ExecuteAsync(UpdateAuthorSuggestionsDto obj)
        {
           
        }
    }
}
