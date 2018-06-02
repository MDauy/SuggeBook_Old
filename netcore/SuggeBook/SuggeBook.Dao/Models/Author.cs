using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dao.Models
{
    public class Author
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MyProperty
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }

        }

        public List<Book> Books { get; set; }


    }
}
