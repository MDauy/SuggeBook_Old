using Newtonsoft.Json;
using System.Collections.Generic;

namespace SuggeBook.Api.ViewModels
{
    public class CreateUserViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "favorite_categories")]
        public IList<string> FavoriteCategories { get; set; }
    }
}
