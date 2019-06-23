using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using SuggeBook.Domain.Model;
using System.Collections.Generic;

namespace SuggeBook.Api.ViewModels
{
    [Serializable]
    public class CreateSuggestionViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [Required]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "bookId")]
        public string BookId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "authorId")]
        public string AuthorId { get; set; }
    }
}
