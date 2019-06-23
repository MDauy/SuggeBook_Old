using Newtonsoft.Json;

namespace SuggeBook.Api.ViewModels
{
    public class CreateSagaViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
