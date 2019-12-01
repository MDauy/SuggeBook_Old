using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SuggeBook.Framework;

namespace SuggeBook.ViewModels
{
    public class CreateBookViewModel : BaseViewModel
    {
        [Required]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty(PropertyName = "authors_ids")]
        public List<string> AuthorsIds { get; set; }

        [JsonProperty(PropertyName = "year")]
        public string PublishedDate { get; set; }

        [JsonProperty(PropertyName = "isbn10")]
        public string Isbn10 { get; set; }

        [JsonProperty(PropertyName = "isbn13")]
        public string Isbn13 { get; set; }

        [JsonProperty(PropertyName = "saga_id")]
        public string SagaId { get; set; }

        [RequiredIfNot("SagaId", "")]
        [JsonProperty(PropertyName = "saga_position")]
        public double? SagaPosition { get; set; }

        [Required]
        [JsonProperty(PropertyName = "categories")]
        public List<string> Categories { get; set; }

        [JsonProperty(PropertyName ="synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty(PropertyName ="cover")]
        public byte[] Cover { get; set; }
    }
}

