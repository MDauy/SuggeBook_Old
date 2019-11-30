using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SuggeBook.ViewModels
{
    public class UserToConnectViewModel
    {
        [JsonProperty(PropertyName = "usernameOrEmail")]
        public string UsernameOrEmail { get; set; }

        [Required]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
