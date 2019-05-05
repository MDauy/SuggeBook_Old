using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
    public class CreateBookViewModel : BaseViewModel
    {
        [Required]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty(PropertyName = "author_id")]
        public string AuthorId { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "isbn")]
        public string Isbn { get; set; }

        [Required]
        [JsonProperty(PropertyName = "categories")]
        public List<string> Categories { get; set; }

        public Book ToModel()
        {
            return new Book
            {
                Title = Title,
                Author = new Author
                {
                    Id = AuthorId,
                },
                Id = Id,
                Categories = Categories,
                Isbn = Isbn
            };
        }
    }
}
