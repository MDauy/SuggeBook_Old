﻿using SuggeBook.Dto.Models;
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

        SuggestionDto Suggestion();

        List<SuggestionDto> Suggestions(int howMany);

        UserDto User();

        List<UserDto> Users(int howMany);

    }
}
