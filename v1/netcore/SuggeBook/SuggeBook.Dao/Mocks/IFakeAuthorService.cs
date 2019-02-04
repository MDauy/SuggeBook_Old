using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dto.Mocks
{
    public interface IFakeAuthorService
    {
        List<Author> Generate(int howMany);
    }
}
