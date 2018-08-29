using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Business.Contracts
{
    public interface ISuggestionInteractor
    {
        SuggestionDto GetSuggestion(string id);
    }
}
