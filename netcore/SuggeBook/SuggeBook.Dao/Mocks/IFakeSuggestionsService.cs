using SuggeBook.Dao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Dao.Mocks
{
    public interface IFakeSuggestionsService
    {
        List<Suggestion> Generate(int howMany);
    }
}
