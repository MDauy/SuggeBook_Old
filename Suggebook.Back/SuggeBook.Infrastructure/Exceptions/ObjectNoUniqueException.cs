using System;

namespace SuggeBook.Infrastructure.Exceptions
{
    public class ObjectNotUniqueException : Exception
    {
        public override string Message { get; }

        public ObjectNotUniqueException (string objectType, string objectId)
        {
            Message = $"{objectType} {objectId} is not unique";
        }
    }
}
