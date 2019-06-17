using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class SagaDocument : BaseDocument
    {
        public SagaDocument()
        {

        }

        public SagaDocument(Saga saga)
        {
            Title = saga.Title;
            Id = ObjectId.Parse(saga.Id);
        }

        [BsonElement("Title")]
        public string Title { get; set; }

        public Saga ToModel()
        {
            return new Saga()
            {
                Id = Id.ToString(),
                Title = Title
            };
        }
    }
}
