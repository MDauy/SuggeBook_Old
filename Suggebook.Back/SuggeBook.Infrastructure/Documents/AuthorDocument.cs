using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class AuthorDocument : BaseDocument
    {
        [BsonElement("Firstname")]
        public string Firstname { get; set; }

        [BsonElement("Lastname")]
        public string Lastname { get; set; }

        [BsonElement("NbSuggestions")]
        public int NbSuggestions { get; set; }


        public override BaseModel ConvertToModel()
        {
            return new Author
            {
                Firstname = Firstname,
                Lastname = Lastname,
                NbSuggestions = NbSuggestions
            };
        }
    }

}
