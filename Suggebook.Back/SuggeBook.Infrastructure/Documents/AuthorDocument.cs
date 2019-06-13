using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class AuthorDocument : BaseDocument
    {
        public AuthorDocument() { }

        public AuthorDocument(Author author)
        {
            Firstname = author.Firstname;
            Lastname = author.Lastname;
            NbSuggestions = author.NbSuggestions;
        }
        [BsonElement("Firstname")]
        public string Firstname { get; set; }

        [BsonElement("Lastname")]
        public string Lastname { get; set; }

        [BsonElement("NbSuggestions")]
        public int NbSuggestions { get; set; }

        [BsonElement("BabelioId")]
        public string BabelioId { get; set; }

        public Author ToModel()
        {
            return new Author
            {
                Id = Id.ToString(),
                Firstname = Firstname,
                Lastname = Lastname,
                Books = new List<Book>(),
                NbSuggestions = NbSuggestions,
                BabelioId =  BabelioId
            };
        }
    }

}
