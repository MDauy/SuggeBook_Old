using Newtonsoft.Json;
using System;

namespace SuggeBook.Api.ViewModels
{
    [Serializable]
    public class CreateSuggestionViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "suggestion")]
        public SuggestionViewModel Suggestion { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "bookId")]
        public string BookId { get; set; }

        [JsonProperty(PropertyName = "authorId")]
        public string AuthorId { get; set; }
    }
}
