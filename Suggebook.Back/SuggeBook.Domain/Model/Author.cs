using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Author : BaseModel
    {
        public Author()
        {
            this.WrongProperties = string.Empty;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int NbSuggestions { get; set; }
        public IList<Book> Books{ get; set; }

        public string BabelioId { get; set; }
        public override bool TestValidation()
        {

            if (string.IsNullOrEmpty(Lastname))
            {
                WrongProperties += "Lastname is null or empty;";
            }

            return this.TestWrongProperties();
        }
    }
}
