using MongoDB.Bson;

namespace SuggeBookDAL.Dao
{
	public class UserDao : BaseDao
    {
		public string Firstname { get; set; }

		public string Lastname { get; set; }
	}
}
