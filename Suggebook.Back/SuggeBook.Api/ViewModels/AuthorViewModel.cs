using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
	public class AuthorViewModel : BaseViewModel
	{
        public AuthorViewModel ()
        {

        }
		public string Name { get; set; }

        public int NbSuggestions { get; set; }
	}


}
