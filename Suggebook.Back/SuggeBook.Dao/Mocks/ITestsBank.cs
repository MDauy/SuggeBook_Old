using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dto.Mocks
{
    public interface ITestsBank
    {
        AuthorDto Author();

        List<AuthorDto> Authors(int howMany);

        BookDto Book();

        List<BookDto> Books(int howMany);

        Suggestion Suggestion();

        List<Suggestion> Suggestions(int howMany);

        User User();

        List<User> Users(int howMany);

    }
}
