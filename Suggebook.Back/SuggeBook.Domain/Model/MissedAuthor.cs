using SuggeBook.Domain.Exceptions;

namespace SuggeBook.Domain.Model
{
    public class MissedAuthor : BaseModel
    {
        public MissedAuthor()
        {
            WrongProperties = string.Empty;
        }
        public string Name { get; set; }

         public string TriedUrl { get; set; }

        public string StatusCode { get; set; }

        public string Message { get; set; }

        public override bool TestCreationValidation()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WrongProperties += $"MissedAuthor has no name";
            }
           if (!TestWrongProperties())
            {
                throw new InvalidObjectException("MissedAuthor", string.Empty, WrongProperties);
            }
           return true;
        }
    }
}
