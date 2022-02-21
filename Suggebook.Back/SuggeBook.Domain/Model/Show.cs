﻿using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Show:BaseModel
    {
        public string Title { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public ShowType ShowType { get; set; }

        public Show(string title, IEnumerable<Category> categories, ShowType showType)
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
