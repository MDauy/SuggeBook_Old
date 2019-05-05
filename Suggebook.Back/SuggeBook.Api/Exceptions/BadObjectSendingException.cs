using System;

namespace SuggeBook.Api.Exceptions
{
    public class BadObjectSendingException : Exception
    {
        public override string Message { get; }

        public BadObjectSendingException()
        {
            Message = "Object was not correctly mapped";
        }
    }
}
