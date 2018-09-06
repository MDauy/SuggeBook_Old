using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dto.Models
{
    public class InsertBookCommandRequest
    {
        public BookDto BookDto { get; set; }
        public string AuthorId { get; set; }
    }
}
