using System;
using System.Collections.Generic;

namespace SuggeBook.Domain.Model
{
    public class Book : BaseModel
    {
        public List<string> Categories { get; set; }
        public string Edition { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
