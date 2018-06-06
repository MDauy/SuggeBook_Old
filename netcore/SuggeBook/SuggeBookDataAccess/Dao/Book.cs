using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggeBookDataAccess.Dao
{
	public class Book
	{
		public ObjectId Id { get; set; }

		[BsonElement("Title")]
		public string Title { get; set; }

		[BsonElement("AuthorId")]
		public int AuthorId { get; set; }

		[BsonElement("Edition")]
		public string Edition { get; set; }

		[BsonElement("ISBN")]
		public string ISBN { get; set; }

	}
}
