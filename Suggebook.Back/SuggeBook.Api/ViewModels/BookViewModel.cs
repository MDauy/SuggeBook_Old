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

        public string Title { get; set; }

        public BookAuthorViewModel Author { get; set; }

        public int NbSuggestions { get; set; }

        public IList<string> Categories { get; set; }

        
    }
    public struct BookAuthorViewModel
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
    }
}
