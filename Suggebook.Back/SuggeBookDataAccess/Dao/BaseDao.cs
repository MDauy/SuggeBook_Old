using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBookDAL.Dao
{
    public abstract class BaseDao
    {
        public ObjectId Id { get; set; }
    }
}
