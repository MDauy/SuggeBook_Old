using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Api.Dto
{
    public class UpdateBookSuggestionsDto
    {
        public string BookId { get; set; }

        public SuggestionDao Suggestion{ get; set; }
    }
}
