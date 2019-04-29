using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Book : BaseModel
    {
        public Book ()
        {
            WrongProperties = string.Empty;
        }
        public List<string> Categories { get; set; }
        public string Edition { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }

        public override bool IsValid()
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
