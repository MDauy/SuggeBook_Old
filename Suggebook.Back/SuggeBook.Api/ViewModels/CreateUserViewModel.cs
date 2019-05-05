using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
    public class CreateUserViewModel : BaseViewModel
    {
        [Required]
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "favorite_categories")]
        public IList<string> FavoriteCategories { get; set; }

        public User ToModel()
        {
            return new User
            {
                FavoriteCategories = FavoriteCategories,
                Firstname = Firstname,
                Lastname = Lastname,
                Mail = Mail,
                Username = Username
            };
        }
    }
}
