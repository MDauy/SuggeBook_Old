using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBookDAL
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
					_client = new MongoClient("mongodb://sbUser:toto4126@localhost:27017/SuggeBook");
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
					_db = Client.GetDatabase("SuggeBook");
				};

				return _db;
			}
		}



	}
}
