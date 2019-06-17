using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Domain.Model
{
    public class Saga : BaseModel
    {
        public Saga()
        {
            WrongProperties = string.Empty;
        }
        public string Title { get; set; }

        public IList<Book> Books{ get; set; }

        public override bool TestCreationValidation()
        {
            if (string.IsNullOrEmpty(Title))
            {
                WrongProperties += "Title is null or empty";
            }

            return TestWrongProperties();
        }
    }
}
