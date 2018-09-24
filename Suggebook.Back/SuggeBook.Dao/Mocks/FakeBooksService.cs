using System.Collections.Generic;
using Bogus.DataSets;
using Bogus;
using SuggeBook.Dto.Models;
using System;

namespace SuggeBook.Dto.Mocks
{
	public class FakeBooksService : IFakeBooksService
	{
		public FakeBooksService(IFakeSuggestionsService toto)
		{

		}


		public Randomizer Randomizer { get; set; }
		public List<BookDto> Generate(int howMany)
		{
			var Lorem = new Lorem(locale: "fr");
            var testBooks = new Faker<BookDto>().StrictMode(true).RuleFor(b => b.AuthorFullName, f => f.PickRandom(BooksSamples.BooksAuthors)).
                     RuleFor(b => b.Title, f => f.PickRandom(BooksSamples.BooksTitles))
                     .RuleFor(b => b.Categories, () => BooksSamples.GetCategories(3))
                     .RuleFor(b => b.ISBN, f => Guid.NewGuid())
                     .RuleFor(b => b.NbSuggestions, f => 0)
            .RuleFor(b => b.Year, f => f.Date.Past().Year)
            .RuleFor(b => b.Id, "")
            .RuleFor(b => b.AuthorId, "")
            .RuleFor(b => b.Edition, "");


			var books = testBooks.Generate(howMany);

			return books;
		}
	}
}
