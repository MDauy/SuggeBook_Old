using SuggeBook.Dao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dao.Mocks
{
    public interface IFakeAuthorService
    {
        List<Author> Generate(int howMany);
    }
}
