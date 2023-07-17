using SuggeBook.Domain.Exceptions;
namespace SuggeBook.Domain.Model
{
    public abstract class BaseModel
    {
        public string Id { get; set; }

        public abstract void IsValid();

        protected string WrongProperties { get; set; }

        protected void TestWrongProperties ()
        {
            if (!string.IsNullOrEmpty(WrongProperties))
            {
                throw new InvalidObjectException(this.GetType().ToString(), this.Id, WrongProperties);
            }
        }
    }
}
