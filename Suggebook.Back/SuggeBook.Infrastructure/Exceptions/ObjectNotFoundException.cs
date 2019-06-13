using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Infrastructure.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public override string Message { get;}
        public ObjectNotFoundException (string objectType, string objectId)
        {
            Message = $"{objectType} {objectId} was not found";
        }
    }
}
