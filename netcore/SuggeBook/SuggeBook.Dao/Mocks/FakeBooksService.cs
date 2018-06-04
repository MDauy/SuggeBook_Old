using System.Collections.Generic;
using Bogus.DataSets;
using Bogus;
using SuggeBook.Dto.Models;

namespace SuggeBook.Dto.Mocks
{
    public class FakeBooksService : IFakeBooksService
    {
        public FakeBooksService(IFakeSuggestionsService toto)
        {

        }

        
        public Randomizer Randomizer { get; set; }
        public List<Book> Generate(int howMany)
        {
            var Lorem = new Lorem(locale: "fr");
            var testBooks = new Faker<Book>().StrictMode(true).RuleFor(b => b.AuthorFullName, f => f.PickRandom(BooksSamples.BooksAuthors)).
                 RuleFor(b => b.Title, f => f.PickRandom(BooksSamples.BooksTitles))
                 .RuleFor(b => b.Categories, () => BooksSamples.GetCategories(3))
                 .RuleFor(b => b.AuthorFullName, f => f.Name.FullName())
            .RuleFor(b => b.Resume, () => Lorem.Sentence(87))
            .RuleFor(b => b.Year, () => "1998")
            .RuleFor(b => b.Edition, () => "Actes Sud");

            var books = testBooks.Generate(howMany);

            return books;
        }
    }
}
