using Newtonsoft.Json;

namespace SuggeBook.Api.ViewModels
{
    public class CreateAuthorViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }
    }
}
