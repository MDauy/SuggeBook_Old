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
            Name = author.Name;
            NbSuggestions = author.NbSuggestions;
        }
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("NbSuggestions")]
        public int NbSuggestions { get; set; }


        public Author ToModel()
        {
            return new Author
            {
                Id = Id.ToString(),
                Name = Name,
                Books = new List<Book>(),
                NbSuggestions = NbSuggestions
            };
        }
    }

}
