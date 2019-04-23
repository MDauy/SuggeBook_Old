using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SuggeBookDAL.Persistence.Documents
{
	public class BookDocument : BaseDocument
	{
		[BsonElement("Title")]
		public string Title { get; set; }

		[BsonElement("Edition")]
		public string Edition { get; set; }

		[BsonElement("ISBN")]
		public string ISBN { get; set; }

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
    }
}
