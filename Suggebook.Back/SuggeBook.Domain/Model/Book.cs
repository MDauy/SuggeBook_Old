using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Book : BaseModel
    {
        public Book ()
        {
            WrongProperties = string.Empty;
        }

        public IList<string> Categories { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }

        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }

        public string PublishedDate { get; set; }

        public override bool TestValidation()
        {
            if (string.IsNullOrEmpty(Title))
            {
                WrongProperties += $"Title is null or empty;";
            }

            if (Author == null)
            {
                WrongProperties += "Author is null;";
            }

            return TestWrongProperties();
        }
    }
}
