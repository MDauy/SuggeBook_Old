using System.Collections.Generic;
using Newtonsoft.Json;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
    public class SagaViewModel
    {
        public SagaViewModel()
        {

        }

        public SagaViewModel(Saga saga)
        {
            Books = new List<BookViewModel>();
            Title = saga.Title;
            Id = saga.Id;
            foreach (var book in saga.Books)
            {
                Books.Add(new BookViewModel(book));
            }
        }

        [JsonProperty(PropertyName = "books")]
        public List<BookViewModel> Books{ get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
