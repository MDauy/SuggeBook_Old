using Newtonsoft.Json;
using System;

namespace SuggeBook.Dto.Models
{
    [Serializable]
    public class InsertSuggestionDto
    {
        [JsonProperty(PropertyName = "suggestion")]
        public SuggestionDto Suggestion { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "bookId")]
        public string BookId { get; set; }

        [JsonProperty(PropertyName = "authorId")]
        public string AuthorId { get; set; }
    }
}
