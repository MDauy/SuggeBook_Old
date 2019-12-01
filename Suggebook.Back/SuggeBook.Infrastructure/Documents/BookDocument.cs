using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Bson;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class BookDocument : BaseDocument
    {
        public BookDocument() { }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("ISBN10")]
        public string Isbn10 { get; set; }

        [BsonElement("ISBN13")]
        public string Isbn13 { get; set; }

        [BsonElement("Categories")]
        public IEnumerable<string> Categories { get; set; }

        [BsonElement("Authors")]
        public IEnumerable<BookAuthorDocument> Authors { get; set; }

        [BsonElement("NbSuggestions")]
        public int NbSuggestions { get; set; }

        [BsonElement("PublishedDate")]
        public string PublishedDate { get; set; }

        [BsonElement("Saga")]
        public SagaDocument Saga { get; set; }

        [BsonElement("SagaPosition")]
        public double? SagaPosition { get; set; }

        [BsonElement("Synopsys")]
        public string Synopsis { get; set; }

        [BsonElement("Cover")]
        public byte[] Cover { get; set; }

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
}
