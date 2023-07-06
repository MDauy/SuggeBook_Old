using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Show : Oeuvre
    {
        public ShowType ShowType { get; set; }

        public Show(string title, IEnumerable<string> categories, ShowType showType)
        {
            this.Categories = categories;
            this.Title = title;
            this.ShowType = showType;
        }
        public override bool TestCreationValidation()
        {
            if (string.IsNullOrEmpty(Title))
                WrongProperties += $"Title is null or empty;";

            if (Categories == null)
                WrongProperties += $"Title is null or empty;";

            if (ShowType == ShowType.None)
                WrongProperties += $"ShowType is None";

            return TestWrongProperties();
        }
    }
}
