using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Dto.Mocks
{
    public interface IFakeSuggestionsService
    {
        List<Suggestion> Generate(int howMany);
    }
}
