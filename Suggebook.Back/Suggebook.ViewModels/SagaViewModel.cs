using System.Collections.Generic;
using Newtonsoft.Json;

namespace SuggeBook.ViewModels
{
    public class SagaViewModel : BaseViewModel
    {
        public SagaViewModel()
        {

        }
        [JsonProperty(PropertyName = "books")]
        public List<BookViewModel> Books{ get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

    }
}
