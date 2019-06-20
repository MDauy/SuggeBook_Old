using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{public class Book : BaseModel
    {
        public Book ()
        {
            WrongProperties = string.Empty;
        }

        public IList<string> Categories { get; set; }
        public string Title { get; set; }
        public IList<Author> Authors { get; set; }

        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }

        public string PublishedDate { get; set; }

        public Saga Saga { get; set; }

        public double? SagaPosition { get; set; }

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

            return TestWrongProperties();
        }
    }
}
