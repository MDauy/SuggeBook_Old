using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SuggeBookDAL.Persistence.Documents
{
    public class UserDocument : BaseDocument
    {
        [BsonElement("Firstname")]
        public string Firstname { get; set; }

        [BsonElement("Lastname")]
        public string Lastname { get; set; }

        [BsonElement("FavoriteCategories")]
        public List<string> FavoriteCategories { get; set; }

        [BsonElement("Mail")]
        public string Mail { get; set; }

        [BsonElement("UserName")]
        public string UserName{ get; set; }
    }
}
