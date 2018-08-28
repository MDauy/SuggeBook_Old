using SuggeBook.Dto.Models;
using System.Collections.Generic;

namespace SuggeBook.Dto.Mocks
{
    public interface IFakeBooksService
    {
        List<BookDto> Generate(int howMany);
    }
}
