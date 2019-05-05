using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Domain.Exceptions
{
    public class ObjectExistingException : Exception
    {
        public override string Message { get; }

        public ObjectExistingException(string objectType, string objectIdentifier)
        {
            Message = $"{objectType} {objectIdentifier} already exists";
        }
    }
}
