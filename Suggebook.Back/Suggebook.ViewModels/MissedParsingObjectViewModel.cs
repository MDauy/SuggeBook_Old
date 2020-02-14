using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.ViewModels
{
   public abstract class MissedParsingObjectViewModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Message { get; set; }
    }
}
