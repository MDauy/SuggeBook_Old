using Newtonsoft.Json;
using System;

namespace SuggeBook.Api.Dto
{
    [Serializable]
    public class InsertSuggestionViewModel : BaseViewModel
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
