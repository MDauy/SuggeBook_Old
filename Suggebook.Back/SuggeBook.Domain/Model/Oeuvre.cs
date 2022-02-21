using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Domain.Model
{
    public abstract class Oeuvre: BaseModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public OeuvreType Type{ get; set; }

        public IEnumerable<Category> Categories { get; set; }

    }
}
