using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dto.Models
{
    public class Author
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }

        }

        public List<Book> Books { get; set; }

        public struct Book
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public int Year { get; set; }

            public string NumberOfSuggestions { get; set; }
        }
    }

    
}
