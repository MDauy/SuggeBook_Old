using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
    [Serializable]
    public class SuggestionViewModel : BaseViewModel
    {
        public SuggestionViewModel() { }

        public SuggestionViewModel(Suggestion suggestion)
        {
            Id = suggestion.Id;
            Title = suggestion.Title;
            Categories = suggestion.Book.Categories;
            BookAuthors = new List<SuggestionAuthorViewModel>();
            foreach (var author in suggestion.Book.Authors)
            {
                BookAuthors.Add (new SuggestionAuthorViewModel
                {
                     Id = author.Id,
                Fullname = author.Name
                });
            }
            CreationDate = suggestion.CreationDate;
            BookTitle = suggestion.Book.Title;
            CreatorUsername = suggestion.User.Username;
            Content = suggestion.Content;
        }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "bookTitle")]  
        public string BookTitle { get; set; }

        [JsonProperty(PropertyName = "bookAuthors")]
        public IList<SuggestionAuthorViewModel> BookAuthors { get; set; }

        [JsonProperty(PropertyName = "creatorUsername")]
        public string CreatorUsername { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime? CreationDate { get; set; }

        public struct SuggestionAuthorViewModel
        {
            public string Id { get; set; }

            public string  Fullname { get; set; }
        }

    }
}
