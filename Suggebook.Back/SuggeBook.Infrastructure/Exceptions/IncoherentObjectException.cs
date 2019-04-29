using System;

namespace SuggeBook.Infrastructure.Exceptions
{
    public class IncoherentObjectException : Exception
    {
        public override string  Message { get; }

        public IncoherentObjectException(string obj)
        {
            Message = $"{obj} is not a valid object";
        }
    }
}
