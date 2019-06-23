using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class UserDocument : BaseDocument
    {
        public UserDocument()
        {
        }

        [BsonElement("Firstname")]
        public string Firstname { get; set; }

        [BsonElement("Lastname")]
        public string Lastname { get; set; }

        [BsonElement("FavoriteCategories")]
        public IList<string> FavoriteCategories { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("UserName")]
        public string UserName{ get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
