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
            FirstName = author.Firstname;
            LastName = author.Lastname;
            NbSuggestions = author.NbSuggestions;
        }
		public string FirstName { get; set; }

		public string LastName { get; set; }

        public int NbSuggestions { get; set; }
	}


}
