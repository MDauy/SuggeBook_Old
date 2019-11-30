using Newtonsoft.Json;

namespace SuggeBook.ViewModels
{
    public class CreateSagaViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
