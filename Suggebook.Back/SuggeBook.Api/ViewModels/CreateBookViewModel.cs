using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Api.ViewModels
{
    public class CreateBookViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "author_id")]
        public string AuthorId { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "isbn")]
        public Guid Isbn { get; set; }

        [JsonProperty(PropertyName = "edition")]
        public string Edition { get; set; }
    }
}
