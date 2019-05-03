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

        public UserDocument(User user)
        {
            this.Firstname = user.Firstname;
            this.Lastname = user.Lastname;
            this.FavoriteCategories = user.FavoriteCategories;
            this.Mail = user.Mail;
            this.UserName = user.UserName;
        }

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
