using MongoDB.Bson.Serialization.Attributes;

namespace SuggeBook.Infrastructure.Documents
{
    public class AuthorDocument : BaseDocument
    {
        public AuthorDocument() { }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("NbSuggestions")]
        public int NbSuggestions { get; set; }
    }

}
