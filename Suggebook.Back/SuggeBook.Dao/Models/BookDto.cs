using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using System;
using System.Collections.Generic;

namespace SuggeBook.Dto.Models
{
    public class BookDto
    {
        public BookDto()
        {

        }

        public BookDto (BookDao dao)
        {
            CustomAutoMapper.Map<BookDao, BookDto>(dao);
        }
        public string Id { get; set; }

        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public int NumberOfSuggestions { get; set; }

        public List<string> Categories { get; set; }

        public int Year { get; set; }

        public Guid ISBN { get; set; }
    }


}
