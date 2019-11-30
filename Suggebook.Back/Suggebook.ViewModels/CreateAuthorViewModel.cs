using Newtonsoft.Json;

namespace SuggeBook.ViewModels
{
    public class CreateAuthorViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
