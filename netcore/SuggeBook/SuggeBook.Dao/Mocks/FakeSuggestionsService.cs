using Bogus;
using Bogus.DataSets;
using SuggeBook.Dao.Models;
using System.Collections.Generic;

namespace SuggeBook.Dao.Mocks
{
    public class FakeSuggestionsService : IFakeSuggestionsService
    {

        public FakeSuggestionsService()
        {
            this.Lorem = new Lorem(locale: "fr");
        }

        public Lorem Lorem { get; set; }

        public List<Suggestion> Generate (int howMany)
        {
            var testSuggestions = new Faker<Suggestion>()
                .RuleFor(s => s.BookTitle, f => f.PickRandom<string>(BooksSamples.BooksTitles))
                .RuleFor(s => s.BookAuthor, f => f.PickRandom(BooksSamples.BooksAuthors))
                .RuleFor(s => s.Title, f => Lorem.Sentence(10))
                .RuleFor(s => s.OpinionText, f => Lorem.Sentence(200))
                .RuleFor(s => s.CreatorUsername, f => Lorem.Sentence(2));
            

            var suggestions = testSuggestions.Generate(howMany);

            return suggestions;
        }
    }
}
