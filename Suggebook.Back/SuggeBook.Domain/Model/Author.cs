﻿using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Author : Oeuvre
    {
        public Author()
        {
            this.WrongProperties = string.Empty;
        }

        

        public string Name { get; set; }
        public int NbSuggestions { get; set; }
        public IList<Book> Books { get; set; }
        public override void IsValid()
        {

            if (string.IsNullOrEmpty(Name))
            {
                WrongProperties += "Name is null or empty;";
            }

            this.TestWrongProperties();
        }
    }
}
