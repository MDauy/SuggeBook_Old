using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Author : BaseModel
    {
        public Author()
        {
            this.WrongProperties = string.Empty;
        }

        public string Name { get; set; }
        public int NbSuggestions { get; set; }
        public IList<Book> Books{ get; set; }

        public string BabelioId { get; set; }
        public override bool TestValidation()
        {

            if (string.IsNullOrEmpty(Name))
            {
                WrongProperties += "Name is null or empty;";
            }

            return this.TestWrongProperties();
        }
    }
}
