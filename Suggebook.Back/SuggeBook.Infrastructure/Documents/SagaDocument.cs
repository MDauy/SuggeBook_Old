using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class SagaDocument : BaseDocument
    {
        [BsonElement("Title")]
        public string Title { get; set; }
    }
}
