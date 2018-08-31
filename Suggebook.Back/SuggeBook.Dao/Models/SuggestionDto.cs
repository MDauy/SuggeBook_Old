using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Dto.Models
{
    public class SuggestionDto : BaseDto
    {
        public string Title { get; set; }

        public string BookTitle { get; set; }

        public string BookAuthor { get; set; }

        public string CreatorUsername { get; set; }

        public string OpinionText { get; set; }

        //A remplacer par un objet de type Category ?
        public List<string> Categories { get; set; }

        public struct Category
        {
            public string Label { get; set; }
        }
    }
}
