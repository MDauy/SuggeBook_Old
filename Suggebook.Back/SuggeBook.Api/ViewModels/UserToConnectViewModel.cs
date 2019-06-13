using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuggeBook.Api.ViewModels
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
