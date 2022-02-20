using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Show
    {
        public string Title { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public Show (string title, IEnumerable<Category> categories)
        {
            this.Categories = categories;
            this.Title = title;
        }
    }
}
