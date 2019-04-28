using System;
using System.Collections.Generic;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.Dto
{
    public class BookDto : BaseDto
    {
        public BookDto()
        {

        }

        public BookDto (Book dao)
        {
            Framework.CustomAutoMapper.Map<Book, BookDto>(dao);
        }

        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public string AuthorId { get; set; }

        public int NbSuggestions { get; set; }

        public List<CategoryEnum> Categories { get; set; }

        public int Year { get; set; }

        public Guid Isbn { get; set; }

        public string Edition { get; set; }
    }


}
