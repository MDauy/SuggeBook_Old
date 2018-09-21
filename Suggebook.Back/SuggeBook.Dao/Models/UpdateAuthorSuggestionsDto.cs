using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dto.Models
{
    public class UpdateAuthorSuggestionsDto
    {
        public string AuthorId { get; set; }

        public SuggestionDto Suggestion { get; set; }
    }
}
