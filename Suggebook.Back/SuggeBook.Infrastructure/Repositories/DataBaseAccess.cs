using MongoDB.Driver;
using System.Configuration;

namespace SuggeBook.Infrastructure.Repositories
{
	public static class DataBaseAccess
	{
		private static MongoClient _client;
		private static IMongoDatabase _db;

		public static MongoClient Client
		{
			get
			{
				if (_client == null)
				{
                    var databseName = 
					_client = new MongoClient("mongodb://suggebook_admin:sb_admin@localhost:27017/suggebook");
				}
				return _client;
			}

		}

		public static IMongoDatabase Db
		{
			get
			{
				if (_db == null)
				{
					_db = Client.GetDatabase("suggebook");
				};

				return _db;
			}
		}



	}
}
