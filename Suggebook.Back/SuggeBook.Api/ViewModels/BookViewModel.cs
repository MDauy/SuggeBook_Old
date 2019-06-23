using Newtonsoft.Json;
using SuggeBook.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace SuggeBook.Api.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public BookViewModel()
        {

        }

        //public BookViewModel(Book book)
        //{
        //    Id = book.Id;
        //    Title = book.Title;            
        //    Categories = book.Categories;

        //    Authors = book.Authors.ToList().ConvertAll(b =>
        //    {
        //        return new BookAuthorViewModel
        //        {
        //            Name = b.Name,
        //            Id = b.Id
        //        };
        //    });
        //}

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "authors")]
        public IList<BookAuthorViewModel> Authors { get; set; }

        [JsonProperty(PropertyName = "nb_suggestions")]
        public int NbSuggestions { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty(PropertyName = "published_date")]
        public string PublishedDate { get; set; }

        [JsonProperty(PropertyName = "saga_id")]
        public string SagaId { get; set; }

        [JsonProperty(PropertyName = "saga_position")]
        public double? SagaPosition { get; set; }
    }
    public struct BookAuthorViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string Name { get; set; }
    }
}
