using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SuggeBook.Api.Dto
{
    [Serializable]
    public class SuggestionViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "bookTitle")]  
        public string BookTitle { get; set; }

        [JsonProperty(PropertyName = "bookAuthor")]
        public string BookAuthor { get; set; }

        [JsonProperty(PropertyName = "creatorUsername")]
        public string CreatorUsername { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public List<CategoryEnum> Categories { get; set; }

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime? CreationDate { get; set; }

    }
}
