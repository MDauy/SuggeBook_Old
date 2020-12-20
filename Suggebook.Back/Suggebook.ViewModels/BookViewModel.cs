using Newtonsoft.Json;
using System.Collections.Generic;

namespace SuggeBook.ViewModels
{
    public class BookViewModel : BaseViewModel 
    {
        public BookViewModel()
        {
        }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "authors")]
        public List<AuthorViewModel> Authors { get; set; }

        [JsonProperty(PropertyName = "nb_suggestions")]
        public int NbSuggestions { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IEnumerable<string> Categories { get; set; }

        [JsonProperty(PropertyName = "published_date")]
        public string PublishedDate { get; set; }

        [JsonProperty(PropertyName = "saga_id")]
        public string SagaId { get; set; }

        [JsonProperty(PropertyName = "saga_position")]
        public double? SagaPosition { get; set; }

        [JsonProperty(PropertyName ="synopsis")]
        public string Synopsis { get; set; }

    }
    public struct BookAuthorViewModel
    {
        [JsonProperty(PropertyName = "fullname")]
        public string Name { get; set; }
    }
}
