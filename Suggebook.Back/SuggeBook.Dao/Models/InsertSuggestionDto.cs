using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dto.Models
{
    public class InsertSuggestionDto
    {
        public SuggestionDto Suggestion { get; set; }

        public string UserId { get; set; }

        public string BookId { get; set; }

        public string AuthorId { get; set; }
    }
}
