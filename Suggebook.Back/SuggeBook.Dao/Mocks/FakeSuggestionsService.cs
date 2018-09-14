using Bogus;
using Bogus.DataSets;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using System.Collections.Generic;

namespace SuggeBook.Dto.Mocks
{
    public class FakeSuggestionsService : IFakeSuggestionsService
    {

        public FakeSuggestionsService()
        {
            this.Lorem = new Lorem(locale: "fr");
        }

        public Lorem Lorem { get; set; }

        public List<SuggestionDto> Generate(int howMany)
        {
            var testSuggestions = new Faker<SuggestionDto>()
                .RuleFor(s => s.BookTitle, f => f.PickRandom<string>(BooksSamples.BooksTitles))
                .RuleFor(s => s.BookAuthor, f => f.PickRandom(BooksSamples.BooksAuthors))
                .RuleFor(s => s.Title, f => Lorem.Sentence(10))
                .RuleFor(s => s.Content, f => Lorem.Sentence(200))
                .RuleFor(s => s.CreatorUsername, f => f.Name.FullName())
                .RuleFor(s => s.Categories, f => BooksSamples.GetCategories(5))
            .RuleFor(b => b.Id, "");

            var suggestions = testSuggestions.Generate(howMany);

            return suggestions;
        }
    }
}
