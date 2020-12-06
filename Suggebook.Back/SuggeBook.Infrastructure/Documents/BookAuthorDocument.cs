using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class BookAuthorDocument : BaseDocument
    {
        public BookAuthorDocument(Author author)
        {
            Oid = new ObjectId(author.Id);
            Name = author.Name;
        }

        public BookAuthorDocument()
        {

        }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
