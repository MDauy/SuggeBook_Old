using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggeBookDAL.Dao
{
	public class BookDao : BaseDao
	{
		[BsonElement("Title")]
		public string Title { get; set; }

		[BsonElement("AuthorId")]
		public ObjectId AuthorId { get; set; }

		[BsonElement("Edition")]
		public string Edition { get; set; }

		[BsonElement("ISBN")]
		public string ISBN { get; set; }

    }
}
