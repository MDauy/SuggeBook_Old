using MongoDB.Bson;

namespace SuggeBookDAL.Dao
{
	public class User
    {
		public ObjectId Id { get; set; }

		public string Firstname { get; set; }

		public string Lastname { get; set; }
	}
}
