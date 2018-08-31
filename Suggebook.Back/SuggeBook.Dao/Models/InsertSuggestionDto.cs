using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dto.Models
{
    public class InsertSuggestionDto
    {
        public SuggestionDto Suggestion { get; set; }

        public int UserId { get; set; }
    }
}
