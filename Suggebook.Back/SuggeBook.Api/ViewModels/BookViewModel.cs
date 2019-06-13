using Newtonsoft.Json;
using SuggeBook.Domain.Model;
using System.Collections.Generic;

namespace SuggeBook.Api.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public BookViewModel()
        {

        }

        public BookViewModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = new BookAuthorViewModel()
            {
                Id = book.Author.Id,
                Fullname = $"{book.Author.Firstname} {book.Author.Lastname}"
            };
            Categories = book.Categories;
        }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "author")]
        public BookAuthorViewModel Author { get; set; }

        [JsonProperty(PropertyName = "nb_suggestions")]
        public int NbSuggestions { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<string> Categories { get; set; }

        
    }
    public struct BookAuthorViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string Fullname { get; set; }
    }
}
