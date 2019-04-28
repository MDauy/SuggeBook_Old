using System;
using System.Collections.Generic;

namespace SuggeBook.Api.Dto
{
	public class AuthorDto : BaseDto
	{
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

        public List<Book> Books { get; set; }

		public struct Book
		{
			public Guid Isbn { get; set; }

			public string Title { get; set; }

			public int Year { get; set; }

			public string NbSuggestions { get; set; }
		}
	}


}
