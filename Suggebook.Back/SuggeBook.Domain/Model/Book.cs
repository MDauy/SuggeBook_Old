using System;
using System.Collections.Generic;
using System.Linq;

namespace SuggeBook.Domain.Model
{public class Book : Oeuvre
    {
        public Book ()
        {
            WrongProperties = string.Empty;
        }

        public IEnumerable<Author> Authors { get; set; }

        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }

        public string PublishedDate { get; set; }

        public Saga Saga { get; set; }

        public double? SagaPosition { get; set; }

        public string Synopsis { get; set; }

        public byte[] Cover { get; set; }

        public List<string>AuthorsIds ()
        {
            return Authors.ToList().Select(author => author.Id).ToList();
        }

        public override bool TestCreationValidation()
        {
            if (string.IsNullOrEmpty(Title))
            {
                WrongProperties += $"Title is null or empty;";
            }

            if (Authors == null)
            {
                WrongProperties += "Author is null;";
            }

            foreach (var category in Categories)
            {
                if (!Enum.IsDefined(typeof(Category), category))
                {
                    WrongProperties += $"{category} doesn't exist";
                }
            }

            return TestWrongProperties();
        }
    }
}
