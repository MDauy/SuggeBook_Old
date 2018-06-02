using SuggeBook.Dao.Models;
using System.Collections.Generic;

namespace SuggeBook.Dao.Mocks
{
    public interface IFakeBooksService
    {
        List<Book> Generate(int howMany);
    }
}
