using SuggeBook.Domain.Model;
using SuggeBook.Framework;
using System;
using System.Collections.Generic;

namespace SuggeBook.Api.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public BookViewModel()
        {

        }

        public BookViewModel(Book dao)
        {
            CustomAutoMapper.Map<Book, BookViewModel>(dao);
        }

        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public string AuthorId { get; set; }

        public int NbSuggestions { get; set; }

        public List<CategoryEnum> Categories { get; set; }

        public int Year { get; set; }
    }
}
