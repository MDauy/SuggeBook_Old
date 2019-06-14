using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
	public class AuthorViewModel : BaseViewModel
	{
        public AuthorViewModel ()
        {

        }

        public AuthorViewModel(Author author)
        {
            Id = author.Id;
            Name = author.Name;
            NbSuggestions = author.NbSuggestions;
        }
		public string Name { get; set; }

        public int NbSuggestions { get; set; }
	}


}
