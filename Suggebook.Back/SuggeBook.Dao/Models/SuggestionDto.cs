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

        public string Content { get; set; }
        
        public List<CategoryEnum> Categories { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
