
namespace SuggeBook.Api.Exceptions
{
    public class ObjectCreationException: System.Exception
    {
        public override string Message { get;}

        public ObjectCreationException(string objectType, string obj)
        {
            Message = $"Problem creating {objectType} : obj";
        }
    }
}
