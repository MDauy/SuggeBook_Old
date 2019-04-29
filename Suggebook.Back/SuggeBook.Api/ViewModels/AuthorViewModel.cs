using System;
using System.Collections.Generic;

namespace SuggeBook.Api.ViewModels
{
	public class AuthorViewModel : BaseViewModel
	{
        public AuthorViewModel ()
        {

        }
        

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string FullName
		{
			get
			{
				return $"{this.FirstName} {this.LastName}";
			}
		}

        public int NbSuggestions { get; set; }

        public IList<AuthorBook> Books { get; set; }

		public struct AuthorBook
		{
			public Guid Isbn { get; set; }

			public string Title { get; set; }

			public int Year { get; set; }

			public string NbSuggestions { get; set; }
		}
	}


}
