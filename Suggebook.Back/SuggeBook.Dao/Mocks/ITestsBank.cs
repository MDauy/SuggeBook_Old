using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dto.Mocks
{
    public interface ITestsBank
    {
        Author Author();

        List<Author> Authors(int howMany);

        Book Book();

        List<Book> Books(int howMany);

        Suggestion Suggestion();

        List<Suggestion> Suggestions(int howMany);

        User User();

        List<User> Users(int howMany);

    }
}
