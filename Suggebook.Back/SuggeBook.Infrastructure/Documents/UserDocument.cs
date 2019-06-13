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
            Email = user.Email;
            UserName = user.Username;
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

        public User ToModel()
        {
            return new User
            {
                Id = Id.ToString(),
                Firstname = Firstname,
                Lastname = Lastname,
                FavoriteCategories = FavoriteCategories,
                Email = Email,
                Username = UserName
            };
        }
    }
}
