using System;

namespace SuggeBook.Domain.Exceptions
{
    public class InvalidObjectException : Exception
    {
        public override string Message { get; }

        public InvalidObjectException(string objectType, string objectId, string properties)
        {
            Message = $"{objectType} {objectId} has a problems : {properties}";
        }
    }
}
