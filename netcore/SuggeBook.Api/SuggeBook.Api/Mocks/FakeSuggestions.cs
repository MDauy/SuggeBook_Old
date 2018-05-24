using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using SuggeBook.Api.Models;

namespace SuggeBook.Api.Mocks
{
    public class FakeSuggestions : IFakeSuggestions
    {
        public Randomizer Randomizer{ get; set; }

        public void Generate ()
        {
            var testSuggestions = new Faker<Suggestion>().StrictMode(true)
                .RuleFor(s => s.BookTitle, f => f.PickRandom(BooksSamples.BooksTitles))
                .RuleFor(s => s.BookAuthor, f => f.PickRandom(BooksSamples.BooksAuthors))
                .RuleFor(s => s.Rating, f => f.Random.Double (0, 5))
                .RuleFor(s => s.Title, f => f.Random.String (f.Random.Number (0, 120)))
                .RuleFor(s => s.OpinionText, f => f.Random.String(f.Random.Number(0, 200)))
                .RuleFor(s => s.CreatorUsername, f => f.Random.String(f.Random.Number(0, 10)));


            var suggestions = testSuggestions.Generate(13);
        }
    }
}
