using System.Collections.Generic;
using Bogus;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;

namespace SuggeBook.Dto.Mocks
{
    public class FakeUserService : IFakeUserService
    {
        private IFakeBooksService _fakeBooksService;
        private IFakeSuggestionsService _fakeSuggestionsService;

        public FakeUserService(IFakeBooksService fakeBooksService, IFakeSuggestionsService fakeSuggestionsService)
        {
            this._fakeSuggestionsService = fakeSuggestionsService;

            this._fakeBooksService = fakeBooksService;
        }

        /// <summary>
        /// Génère un certain nombre d'utilisateurs au hasard
        /// </summary>
        /// <param name="howMany"></param>
        /// <returns></returns>
        public List<User> Generate(int howMany)
        {
            var testUser = new Faker<User>().StrictMode(true)
                .RuleFor(u => u.UserName, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(u => u.Books, f => SuggeBookAutoMapper.MapLists<BookDto, User.Book>(_fakeBooksService.Generate(6)))
                .RuleFor(u => u.Suggestions, f => SuggeBookAutoMapper.MapLists<SuggestionDto, User.Suggestion>(_fakeSuggestionsService.Generate(6)))
                .RuleFor (u => u.FavoriteCategories, f => BooksSamples.GetCategories(3))
                .RuleFor(b => b.Id, "");

            return testUser.Generate(howMany);
            
            
        }
        
    }
}
