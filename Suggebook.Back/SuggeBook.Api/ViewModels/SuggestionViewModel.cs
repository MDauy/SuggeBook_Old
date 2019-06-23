using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
    [Serializable]
    public class SuggestionViewModel : BaseViewModel
    {
        public SuggestionViewModel() { }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "bookTitle")]
        public string BookTitle { get; set; }

        [JsonProperty(PropertyName = "creatorUsername")]
        public string CreatorUsername { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime? CreationDate { get; set; }
    }
}
