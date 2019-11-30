using SuggeBook.Domain.Exceptions;
namespace SuggeBook.Domain.Model
{
    public abstract class BaseModel
    {
        public string Id { get; set; }

        public abstract bool TestCreationValidation();

        protected string WrongProperties { get; set; }

        protected bool TestWrongProperties ()
        {
            if (!string.IsNullOrEmpty(WrongProperties))
            {
                throw new InvalidObjectException(this.GetType().ToString(), this.Id, WrongProperties);
            }
            return true;
        }
    }
}
