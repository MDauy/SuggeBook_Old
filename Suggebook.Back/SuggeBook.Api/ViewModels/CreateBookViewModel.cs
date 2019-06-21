using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SuggeBook.Domain.Model;
using SuggeBook.Framework;

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

        public Book ToModel()
        {
            return new Book
            {
                Title = Title,
                Authors = new List<Author>()
                {
                    new Author {Id = AuthorId}
                },
                Id = Id,
                Categories = Categories,
                Isbn10 = Isbn10,
                Isbn13 = Isbn13,
                PublishedDate = PublishedDate,
                Saga = new Saga
                {
                    Id = SagaId
                },
                SagaPosition = SagaPosition
            };
        }
    }
}
