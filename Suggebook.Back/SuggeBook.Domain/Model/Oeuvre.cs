using System;
using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public abstract class Oeuvre: BaseModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public OeuvreType Type{ get; set; }
        public int Likes { get; }
        public IEnumerable<string> Categories { get; set; }

    }
}
