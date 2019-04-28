using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Domain.Model
{
    public abstract class BaseModel
    {
        public string Id { get; set; }

        public abstract bool IsValid();
    }
}
