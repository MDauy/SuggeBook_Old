using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class MissedAuthorDocument : BaseDocument
    {
        public MissedAuthorDocument(){}

        public MissedAuthorDocument(MissedAuthor missedAuthor)
        {
            Name = missedAuthor.Name;
            TriedUrl = missedAuthor.TriedUrl;
            StatusCode = missedAuthor.StatusCode;
            Message = missedAuthor.Message;
        }

        public MissedAuthor ToModel ()
        {
            return new MissedAuthor
            {
                Name = Name,
                Message = Message,
                StatusCode = StatusCode,
                TriedUrl = TriedUrl
            };
        }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("TriedUrl")]
        public string TriedUrl { get; set; }

        [BsonElement("StatusCode")]
        public string StatusCode { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }
    }
}
