using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using SuggeBook.Dao.Models;

namespace SuggeBook.Dao.Mocks
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

        public FakeUserService()
        {

        }


        /// <summary>
        /// Génère un certain nombre d'utilisateurs au hasard
        /// </summary>
        /// <param name="howMany"></param>
        /// <returns></returns>
        public List<User> Generate(int howMany)
        {
            var testUser = new Faker<User>().StrictMode(true).RuleFor(u => u.UserName, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(u => u.Books, () => _fakeBooksService.Generate(5))
                .RuleFor(u => u.Suggestions, () => _fakeSuggestionsService.Generate(10))
            .RuleFor(u => u.FavoriteCategories, () => BooksSamples.GetCategories(3));

            return testUser.Generate(howMany);
            
        }
        
    }
}
