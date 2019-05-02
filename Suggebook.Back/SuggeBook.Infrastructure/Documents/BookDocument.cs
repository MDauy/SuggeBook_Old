using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
	public class BookDocument : BaseDocument
	{
		[BsonElement("Title")]
		public string Title { get; set; }

		[BsonElement("Edition")]
		public string Edition { get; set; }

		[BsonElement("ISBN")]
		public string Isbn { get; set; }

        [BsonElement("Categories")]
        public List<string> Categories { get; set; }
        
        [BsonElement("Author")]
        public BookAuthor Author { get; set; }

        [BsonElement("NbSuggestions")]
        public int NbSuggestions { get; set; }

        public class BookAuthor
        {
            public ObjectId Id { get; set; }
            public string FullName { get; set; }
        }

        public override BaseModel ConvertToModel()
        {
            return new Book
            {
                Author = new Author
                {
                    Id = Author.Id.ToString()
                },
                Id = Id.ToString(),
                Categories = Categories,
                Title = Title
            };
        }
    }
}
