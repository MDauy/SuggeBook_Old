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
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            FavoriteCategories = user.FavoriteCategories;
            Mail = user.Mail;
            UserName = user.Username;
        }

        [BsonElement("Firstname")]
        public string Firstname { get; set; }

        [BsonElement("Lastname")]
        public string Lastname { get; set; }

        [BsonElement("FavoriteCategories")]
        public IList<string> FavoriteCategories { get; set; }

        [BsonElement("Mail")]
        public string Mail { get; set; }

        [BsonElement("UserName")]
        public string UserName{ get; set; }

        public User ToModel()
        {
            return new User
            {
                Id = Id.ToString(),
                Firstname = Firstname,
                Lastname = Lastname,
                FavoriteCategories = FavoriteCategories,
                Mail = Mail,
                Username = UserName
            };
        }
    }
}
