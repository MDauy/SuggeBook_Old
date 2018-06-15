using System.Collections.Generic;
using Bogus;
using SuggeBook.Dto.Models;

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
            //var testUser = new Faker<User>().StrictMode(true).RuleFor(u => u.UserName, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))         

            //return testUser.Generate(howMany);
            return null;
            
        }
        
    }
}
