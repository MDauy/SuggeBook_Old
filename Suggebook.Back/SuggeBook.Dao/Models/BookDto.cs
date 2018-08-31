using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using System;
using System.Collections.Generic;

namespace SuggeBook.Dto.Models
{
    public class BookDto : BaseDto
    {
        public BookDto()
        {

        }

        public BookDto (BookDao dao)
        {
            SuggeBookAutoMapper.Map<BookDao, BookDto>(dao);
        }

        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public int NumberOfSuggestions { get; set; }

        public List<string> Categories { get; set; }

        public int Year { get; set; }

        public Guid ISBN { get; set; }
    }


}
