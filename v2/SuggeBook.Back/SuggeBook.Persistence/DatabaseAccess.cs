﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Persistence
{
    public static class DatabaseAccess
    {
        private static MongoClient _client;
        private static IMongoDatabase _db;

        public static MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new MongoClient("http://localhost:27017");
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
                    _db = _client.GetDatabase("SuggeBook");
                };

                return _db;
            }
        }
    }
}
