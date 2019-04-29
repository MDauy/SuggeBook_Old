﻿using System;
using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Suggestion : BaseModel
    {
        public Suggestion ()
        {
            WrongProperties = string.Empty;
        }

        public string Title { get; set; }
        public IList<string> Categories { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Content { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Title))
            {
                WrongProperties += "Title is null or empty";
            }

            if (Book == null)
            {
                WrongProperties += "Book is null";
            }

            if (Book == null)
            {
                WrongProperties += "User is null";
            }

            return TestWrongProperties();
        }
    }
}
