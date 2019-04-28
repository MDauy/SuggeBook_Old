using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Domain.Model
{
    public class Author : BaseModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int NbSuggestions { get; set; }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
