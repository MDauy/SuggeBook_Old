using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBookDataAccess
{
	public class DataAccess
	{
		private MongoClient _client;
		private IMongoDatabase _db;

		public DataAccess()
		{
			_client = new MongoClient("mongodb://localhost:27017");
			_db = _client.GetDatabase("SuggeBook");
			
		}

	}
}
